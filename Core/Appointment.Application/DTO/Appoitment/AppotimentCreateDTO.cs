using System;
using Appointment.Domain.Entities.Identity;
using Appointment.Domain.Entities;
namespace Appointment.Application.DTO.Appoitment;

public class AppotimentCreateDTO
{
    public DateTime AppointmentDate { get; set; }
    public string UserId { get; set; } = null!;
    public AspUser User { get; set; } = null!;

    public int DoctorId { get; set; } 
    public Doctor Doctor { get; set; } = null!;
}
