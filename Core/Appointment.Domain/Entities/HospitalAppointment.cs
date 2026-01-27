using System;
using Appointment.Domain.Entities.Identity;
using Appointment.Application.Enums;
using Appointment.Domain.Entities.Common;
namespace Appointment.Domain.Entities;

public class HospitalAppointment : BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string PatientId { get; set; } = null!; 
    public AspUser Patient { get; set; } = null!;
    public string DoctorId { get; set; } = null!; 
    public Doctor Doctor { get; set; } = null!;
}

