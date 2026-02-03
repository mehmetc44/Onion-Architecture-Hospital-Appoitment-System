using System;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.Doctor;
using Appointment.Application.DTO.HospitalAppoitment;

namespace Appointment.Application.Abstraction.Service;

public interface IDoctorService
{
    Task<List<DoctorDto>> GetDoctorsByDepartmentAsync(string departmentId);
    Task<DoctorDto> GetDoctorByIdAsync(string id);
    Task<List<ViewDoctorHospitalAppointmentDto>> GetDoctorScheduleAsync(string doctorId, DateTime date);
    Task<AppointmentStatsDto> GetDailyStatsAsync(string doctorId, DateTime date);
    Task<DashboardSummaryDto> GetDashboardSummaryAsync(string doctorId);
    Task<bool> CheckDoctorAvailabilityAsync(string doctorId, DateTime date, TimeSpan time, string? excludeAppointmentId = null);
    Task<List<AppointmentSlotDto>> GetAllSlotsAsync(string doctorId, DateTime selectedDate);
    Task<ViewDoctorInfoDto> GetDoctorInfoAsync(string doctorId);
}
