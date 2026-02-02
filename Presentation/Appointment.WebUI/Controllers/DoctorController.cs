using Appointment.Application.Abstraction.Service;
using Appointment.WebUI.Models.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        IHospitalAppointmentService _hospitalAppointmentService;
        IDoctorService _doctorService;
        public DoctorController(IHospitalAppointmentService hospitalAppointmentService, IDoctorService doctorService)
        {
            _hospitalAppointmentService = hospitalAppointmentService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard(DateTime? date)
        {


            var _date = date ?? DateTime.Now.Date;

            var doctorId = "b5e93280-c9b3-437f-9f98-bb0784edbd93";
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
            var doctorId = "b5e93280-c9b3-437f-9f98-bb0784edbd93";
            var appointments = await _doctorService.GetDoctorScheduleAsync(doctorId, selectedDate);
            ViewBag.SelectedDate = selectedDate;
            return View(appointments);
        }
        public async Task<ActionResult> Profile()
        {
            var doctorId = "b5e93280-c9b3-437f-9f98-bb0784edbd93";
            var doctorInfo = await _doctorService.GetDoctorInfoAsync(doctorId);
            return View(doctorInfo);
        }

    }
}
