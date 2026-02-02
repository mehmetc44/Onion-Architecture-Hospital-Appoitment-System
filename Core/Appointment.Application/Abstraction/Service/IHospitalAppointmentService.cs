using Appointment.Application.DTO.HospitalAppoitment;

namespace Appointment.Application.Abstraction.Service;

public interface IHospitalAppointmentService
{
    Task<bool> CreateAppointmentAsync(CreateHospitalAppointmentDto createAppointmentDto);
    Task<bool> CancelAppointmentAsync(string appointmentId);
    Task<bool> CompleteAppointmentAsync(string appointmentId); 
    Task<bool> RescheduleAppointmentAsync(string appointmentId, DateTime newDate, TimeSpan newTime);
    Task<List<ViewHospitalAppointmentDto>> GetAppointmentsAsync(string userId, bool isHistory);

}
