using System;

namespace Appointment.Application.DTO.Doctor;

public class AppointmentStatsDto
{
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int CancelledAppointments { get; set; }

}
