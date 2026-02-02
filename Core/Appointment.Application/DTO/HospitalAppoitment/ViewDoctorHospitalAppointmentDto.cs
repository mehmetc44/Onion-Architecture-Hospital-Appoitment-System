using System;
using Appointment.Domain.Enums;

namespace Appointment.Application.DTO.HospitalAppoitment;

public class ViewDoctorHospitalAppointmentDto
{

    public string Id { get; set; } = null!;
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string PatientId { get; set; } = null!;
    public string PatientUserName { get; set; } = null!;
    public string PatientName { get; set; } = null!;
    public string DoctorName { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public string HospitalName { get; set; } = null!;
    public AppointmentStatus Status { get; set; }
    public string CityName { get; set; } = null!;
}
