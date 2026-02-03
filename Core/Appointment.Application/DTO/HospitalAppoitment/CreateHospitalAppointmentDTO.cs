using System;
using Appointment.Domain.Entities.Identity;
using Appointment.Domain.Entities;
namespace Appointment.Application.DTO.HospitalAppoitment;

public class CreateHospitalAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string PatientId { get; set; } = null!;
    public string DoctorId { get; set; } = null!;
    public string DepartmentId { get; set; } = null!;
    public string HospitalId { get; set; } = null!;
}
