using System;
using Appointment.Domain.Entities.Identity;
using Appointment.Application.Enums;
using Appointment.Domain.Entities.Common;
namespace Appointment.Domain.Entities;

public class HospitalAppointment : BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }

    public string UserId { get; set; } = null!;
    public AspUser User { get; set; } = null!;

    public int DoctorId { get; set; } 
    public Doctor Doctor { get; set; } = null!;
}

