using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.HospitalAppoitment;
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
    private readonly IDoctorService _doctorService;

    public HospitalAppointmentService(IHospitalAppointmentReadRepository readRepo, IHospitalAppointmentWriteRepository writeRepo, AutoMapper.IMapper mapper, IDoctorService doctorService)
    {
        _readHospitalAppointmentRepo = readRepo;
        _writeHospitalAppointmentRepo = writeRepo;
        _mapper = mapper;
        _doctorService = doctorService;
    }

    public async Task<bool> CreateAppointmentAsync(CreateHospitalAppointmentDto createAppointmentDto)
    {
        try
        {
            bool isAvailable = await _doctorService.CheckDoctorAvailabilityAsync(
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

        bool isAvailable = await _doctorService.CheckDoctorAvailabilityAsync(
            appointment.DoctorId,
            newDate,
            newTime,
            appointmentId);

        if (!isAvailable)
            throw new Exception("Seçilen tarih ve saatte doktor müsait değil.");

        appointment.AppointmentDate = newDate;
        appointment.AppointmentTime = newTime;
        appointment.Status = AppointmentStatus.Postponed;
        appointment.UpdatedDate = DateTime.Now;
        _writeHospitalAppointmentRepo.Update(appointment);
        return await _writeHospitalAppointmentRepo.SaveAsync() > 0;
    }
    public async Task<List<ViewHospitalAppointmentDto>> GetAppointmentsAsync(string userId, bool isHistory)
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