using System;
using Appointment.Application.DTO.Doctor;

namespace Appointment.WebUI.Models.Doctor;

public class DoctorDashboardViewModel
    {

        public DoctorDashboardViewModel()
        {
            Summary = new DashboardSummaryDto();
            Stats = new AppointmentStatsDto();
        }
        public DashboardSummaryDto Summary { get; set; }
        public AppointmentStatsDto Stats { get; set; }
        public DateTime FilterDate { get; set; }
    }
