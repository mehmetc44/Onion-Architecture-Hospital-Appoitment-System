using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.Doctor;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.Application.Repositories.Doctor;
using Appointment.Application.Repositories.HospitalAppointment;
using Appointment.Domain.Entities;
using Appointment.Domain.Enums;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorReadRepository _doctorReadRepository;
    private readonly IDoctorWriteRepository _doctorWriteRepository;
    private readonly IHospitalAppointmentReadRepository _readHospitalAppointmentRepo;
    private readonly AutoMapper.IMapper _mapper;
    private readonly IUserService _userService;

    public DoctorService(IDoctorReadRepository doctorReadRepository, IDoctorWriteRepository doctorWriteRepository, IHospitalAppointmentReadRepository readHospitalAppointmentRepo, AutoMapper.IMapper mapper, IUserService userService)
    {
        _doctorReadRepository = doctorReadRepository;
        _doctorWriteRepository = doctorWriteRepository;
        _readHospitalAppointmentRepo = readHospitalAppointmentRepo;
        _mapper = mapper;
        _userService = userService;
    }

    public Task<DoctorDto> GetDoctorByIdAsync(string id)
    {
        var doctor = _doctorReadRepository.GetWhere(d => d.Id == id, tracking: false)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                DepartmentId = d.DepartmentId
            })
            .FirstOrDefault();
        return Task.FromResult(doctor);
    }

    public Task<List<DoctorDto>> GetDoctorsByDepartmentAsync(string departmentId)
    {
        var doctors = _doctorReadRepository.GetWhere(d => d.DepartmentId == departmentId, tracking: false)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                DepartmentId = d.DepartmentId
            })
            .ToList();
        return Task.FromResult(doctors);
    }
    public async Task<DashboardSummaryDto> GetDashboardSummaryAsync(string userId)
    {
        var today = DateTime.Today;
        var startOfMonth = new DateTime(today.Year, today.Month, 1);
        var diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var startOfWeek = today.AddDays(-diff).Date;
        var query = _readHospitalAppointmentRepo.GetAll(tracking: false)
                             .Where(x => x.Doctor.UserId == userId);
        var summary = new DashboardSummaryDto
        {
            TodayCount = await query.CountAsync(x => x.AppointmentDate == today),

            WeekCount = await query.CountAsync(x =>
                x.AppointmentDate >= startOfWeek && x.AppointmentDate <= today),

            MonthCount = await query.CountAsync(x =>
                x.AppointmentDate >= startOfMonth && x.AppointmentDate <= today)
        };

        return summary;
    }
    public async Task<AppointmentStatsDto> GetDailyStatsAsync(string userId, DateTime date)
    {
    var targetDate = date.Date;
    var query = _readHospitalAppointmentRepo.GetAll(tracking: false)
        .Where(x => x.Doctor.UserId == userId && 
                    x.AppointmentDate == targetDate);

    var stats = new AppointmentStatsDto
    {
        TotalAppointments = await query.CountAsync(),
        
        CompletedAppointments = await query.CountAsync(x => x.Status == AppointmentStatus.Completed),
        
        CancelledAppointments = await query.CountAsync(x => x.Status == AppointmentStatus.Cancelled),
    };

    return stats;
}
public async Task<List<ViewDoctorHospitalAppointmentDto>> GetDoctorScheduleAsync(string userId, DateTime date)
{
    var query = _readHospitalAppointmentRepo.GetAll(tracking: false)
        // DoctorId üzerinden değil, Doctor tablosuna git ve oradaki UserId üzerinden filtrele
        .Where(x => x.Doctor.UserId == userId && x.AppointmentDate == date.Date);

    var appointments = await query
        .ProjectTo<ViewDoctorHospitalAppointmentDto>(_mapper.ConfigurationProvider)
        .ToListAsync();

    return appointments.OrderBy(x => x.AppointmentTime).ToList();
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
    public async Task<ViewDoctorInfoDto> GetDoctorInfoAsync(string doctorId)
    {
        var doctor = await _doctorReadRepository.GetWhere(d => d.UserId == doctorId, tracking: false)
            .Select(d => new ViewDoctorInfoDto
            {
                Id = d.Id,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                Email = d.User.Email,
                PhoneNumber = d.User.PhoneNumber,
                UserName = d.User.UserName,
                DateOfBirth = d.User.DateOfBirth,
                HospitalName = d.Department.Hospital.Name,
                DepartmentName = d.Department.Name
            })
            .FirstOrDefaultAsync();
        return doctor;
    }

}
