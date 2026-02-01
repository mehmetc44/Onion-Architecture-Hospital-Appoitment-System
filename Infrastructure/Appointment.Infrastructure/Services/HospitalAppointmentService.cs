using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.Application.Repositories;
using Appointment.Application.Repositories.HospitalAppointment;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Services;

public class HospitalAppointmentService : IHospitalAppointmentService
{
    private readonly IHospitalAppointmentReadRepository _readHospitalAppointmentRepo;
    private readonly IHospitalAppointmentWriteRepository _writeHospitalAppointmentRepo;
    private readonly AutoMapper.IMapper _mapper;

    public HospitalAppointmentService(IHospitalAppointmentReadRepository readRepo, IHospitalAppointmentWriteRepository writeRepo, AutoMapper.IMapper mapper)
    {
        _readHospitalAppointmentRepo = readRepo;
        _writeHospitalAppointmentRepo = writeRepo;
        _mapper = mapper;
    }

    public async Task<bool> CreateAppointmentAsync(CreateHospitalAppointmentDto createAppointmentDto)
    {
        try
        {
            bool isAvailable = await CheckDoctorAvailabilityAsync(
                createAppointmentDto.DoctorId,
                createAppointmentDto.AppointmentDate,
                createAppointmentDto.AppointmentTime);

            if (!isAvailable)
            {
                throw new Exception("Doktor seçilen tarih ve saat için müsait değil.");
            }
            var newAppointment = _mapper.Map<HospitalAppointment>(createAppointmentDto);

            await _writeHospitalAppointmentRepo.AddAsync(newAppointment);
            var rowsAffected = await _writeHospitalAppointmentRepo.SaveAsync();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Randevu oluşturulurken bir hata oluştu: " + ex.Message);
        }
    }

    public async Task<bool> CancelAppointmentAsync(string appointmentId)
    {
        var appointment = await _readHospitalAppointmentRepo.GetByIdAsync(appointmentId);

        if (appointment == null)
            throw new Exception("Randevu bulunamadı.");

        appointment.Status = AppointmentStatus.Cancelled;
        appointment.UpdatedDate = DateTime.Now;
        _writeHospitalAppointmentRepo.Update(appointment);
        return await _writeHospitalAppointmentRepo.SaveAsync() > 0;
    }
    public async Task<bool> CompleteAppointmentAsync(string appointmentId)
    {
        var appointment = await _readHospitalAppointmentRepo.GetByIdAsync(appointmentId);

        if (appointment == null)
            throw new Exception("Randevu bulunamadı.");

        appointment.Status = AppointmentStatus.Completed;
        appointment.UpdatedDate = DateTime.Now;

        _writeHospitalAppointmentRepo.Update(appointment);
        return await _writeHospitalAppointmentRepo.SaveAsync() > 0;
    }

    public async Task<bool> RescheduleAppointmentAsync(string appointmentId, DateTime newDate, TimeSpan newTime)
    {
        var appointment = await _readHospitalAppointmentRepo.GetByIdAsync(appointmentId);

        if (appointment == null)
            throw new Exception("Randevu bulunamadı.");

        if (appointment.AppointmentDate < DateTime.Now)
            throw new Exception("Geçmiş randevunun tarihi değiştirilemez.");

        bool isAvailable = await CheckDoctorAvailabilityAsync(
            appointment.DoctorId,
            newDate,
            newTime,
            appointmentId);

        if (!isAvailable)
            throw new Exception("Seçilen tarih ve saatte doktor müsait değil.");

        appointment.AppointmentDate = newDate;
        appointment.AppointmentTime = newTime;
        appointment.Status = AppointmentStatus.Active;
        appointment.UpdatedDate = DateTime.Now;
        _writeHospitalAppointmentRepo.Update(appointment);
        return await _writeHospitalAppointmentRepo.SaveAsync() > 0;
    }

    public async Task<bool> CheckDoctorAvailabilityAsync(string doctorId, DateTime date, TimeSpan time, string? excludeAppointmentId = null)
    {
        var isBooked = await _readHospitalAppointmentRepo.GetAll(tracking: false)
            .AnyAsync(x => x.DoctorId == doctorId &&
                           x.AppointmentDate.Date == date.Date &&
                           x.AppointmentTime == time &&
                           x.Status != AppointmentStatus.Cancelled &&
                           x.Id != (excludeAppointmentId ?? ""));

        return !isBooked;
    }

    // --- HELPER ---
    public async Task<List<AppointmentSlotDto>> GetAllSlotsAsync(string doctorId, DateTime selectedDate)
    {
        var bookedTimes = await _readHospitalAppointmentRepo.GetAll(tracking: false)
    .Where(x => x.DoctorId == doctorId
             && x.AppointmentDate.Date == selectedDate.Date
             && x.Status != AppointmentStatus.Cancelled)
    .Select(x => x.AppointmentTime)
    .ToListAsync();

        var slots = new List<AppointmentSlotDto>();
        TimeSpan startTime = new TimeSpan(9, 0, 0);
        TimeSpan endTime = new TimeSpan(17, 0, 0);
        TimeSpan interval = TimeSpan.FromMinutes(15);

        while (startTime < endTime)
        {
            bool isPast = (selectedDate.Date < DateTime.Today) ||
                          (selectedDate.Date == DateTime.Today && startTime <= DateTime.Now.TimeOfDay);

            bool isBooked = bookedTimes.Contains(startTime);

            slots.Add(new AppointmentSlotDto
            {
                Time = startTime.ToString(@"hh\:mm"),
                IsAvailable = !(isPast || isBooked)
            });

            startTime = startTime.Add(interval);
        }
        return slots;
    }

    public async Task<List<ViewHospitalAppointmentDto>> GetPatientAppointmentsAsync(string userId, bool isHistory)
    {
        var query = _readHospitalAppointmentRepo.GetAll(tracking: false)
            .Where(x => x.PatientId == userId);

        if (isHistory)
        {
            query = query.Where(x => x.Status == AppointmentStatus.Completed ||
                                     x.Status == AppointmentStatus.Cancelled);
        }
        else
        {
            query = query.Where(x => x.Status == AppointmentStatus.Active ||
                                     x.Status == AppointmentStatus.Postponed);
        }
        var appointmentList = await query
            .ProjectTo<ViewHospitalAppointmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        if (isHistory)
        {
            return appointmentList
                .OrderByDescending(x => x.AppointmentDate)
                .ThenByDescending(x => x.AppointmentTime) 
                .ToList();
        }
        else
        {
            return appointmentList
                .OrderBy(x => x.AppointmentDate)
                .ThenBy(x => x.AppointmentTime)
                .ToList();
        }
    }
}
