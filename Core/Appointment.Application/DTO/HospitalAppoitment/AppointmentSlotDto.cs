using System;

namespace Appointment.Application.DTO.Appoitment;
    public class AppointmentSlotDto
{
    public string Time { get; set; } = null!; 
    public bool IsAvailable { get; set; }
}

