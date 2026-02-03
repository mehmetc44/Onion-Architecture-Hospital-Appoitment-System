using Appointment.Application.Abstraction.Service;
using Appointment.Infrastructure.Services;
using Appointment.WebUI.Models.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebUI.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        IHospitalAppointmentService _hospitalAppointmentService;
        IDoctorService _doctorService;
        IAuthService _authService;

        public DoctorController(IHospitalAppointmentService hospitalAppointmentService, IDoctorService doctorService, IAuthService authService)
        {
            _hospitalAppointmentService = hospitalAppointmentService;
            _doctorService = doctorService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard(DateTime? date)
        {


            var _date = date ?? DateTime.Now.Date;

            var doctorId = _authService.GetActiveUserId();
            var summaryData = await _doctorService.GetDashboardSummaryAsync(doctorId);
            var periodData = await _doctorService.GetDailyStatsAsync(doctorId, _date);
            var model = new DoctorDashboardViewModel
            {
                Summary = summaryData,
                Stats = periodData,
                FilterDate = _date,
            };

            return View(model);
        }
        public async Task<IActionResult> Appointments(DateTime? date)
        {
            DateTime selectedDate = date ?? DateTime.Today;
            var doctorId = _authService.GetActiveUserId();
            var appointments = await _doctorService.GetDoctorScheduleAsync(doctorId, selectedDate);
            ViewBag.SelectedDate = selectedDate;
            return View(appointments);
        }

        public async Task<ActionResult> Profile()
        {
            var doctorId = _authService.GetActiveUserId();
            var doctorInfo = await _doctorService.GetDoctorInfoAsync(doctorId);
            return View(doctorInfo);
        }

    }
}
