using System;

namespace Appointment.Application.DTO.Doctor;

public class DashboardSummaryDto
{
    public int TodayCount { get; set; }
    public int WeekCount { get; set; }
    public int MonthCount { get; set; }
}


