using System;
using Appointment.Application.DTO;
using Appointment.Application.DTO.Appoitment;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.Domain.Entities;

namespace Appointment.Application.Abstraction.Service;

public interface IHospitalAppointmentService
{
    Task<bool> CreateAppointmentAsync(CreateHospitalAppointmentDto createAppointmentDto);
    Task<bool> CancelAppointmentAsync(string appointmentId);
    Task<bool> CompleteAppointmentAsync(string appointmentId); 
    Task<bool> RescheduleAppointmentAsync(string appointmentId, DateTime newDate, TimeSpan newTime);

    Task<bool> CheckDoctorAvailabilityAsync(string doctorId, DateTime date, TimeSpan time, string? excludeAppointmentId = null);
    Task<List<ViewHospitalAppointmentDto>> GetPatientAppointmentsAsync(string userId, bool isHistory);
    Task<List<AppointmentSlotDto>> GetAllSlotsAsync(string doctorId, DateTime selectedDate);
    
    //Task<List<ViewHospitalAppointmentDto>> GetDoctorScheduleAsync(string doctorId, DateTime date);

    //Task<bool> CompleteAppointmentAsync(string appointmentId);
    /// Kartlardaki sayıları döner (Bugün: 5, Bu Hafta: 20 vs.)
    //Task<DoctorDashboardStatsDto> GetDoctorDashboardStatsAsync(string doctorId);

    // Grafik verisini döner (Son 7 günün veya bu haftanın gün bazlı tamamlanma sayıları)
    //Task<List<WeeklyChartDataDto>> GetDoctorWeeklyAnalyticsAsync(string doctorId);

}
