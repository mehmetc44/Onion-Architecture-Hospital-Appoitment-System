using System;
using Appointment.Domain.Enums;

namespace Appointment.Application.DTO.HospitalAppoitment;

public class HospitalAppointmentDto
{
    public string Id { get; set; } = null!;
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string PatientId { get; set; } = null!;
    public string DoctorId { get; set; } = null!;
    public string DepartmentId { get; set; } = null!;
    public string HospitalId { get; set; } = null!;
    public AppointmentStatus Status { get; set; }
}
