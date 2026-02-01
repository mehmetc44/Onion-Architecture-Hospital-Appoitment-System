using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Application.DTO.City;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.WebUI.Models.Appointment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Appointment.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IHospitalService _hospitalService;
        private readonly IDoctorService _doctorService;
        private readonly IHospitalAppointmentService _appointmentService;
        private readonly IDepartmentService _departmentService;

        public HomeController(
            ICityService cityService,
            IHospitalService hospitalService,
            IDoctorService doctorService,
            IHospitalAppointmentService appointmentService,
            IDepartmentService departmentService)
        {
            _cityService = cityService;
            _departmentService = departmentService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }
        [HttpGet("home/appointment")]
        public async Task<ActionResult> Appointment()
        {
            var model = new AppointmentViewModel();
            return View(model);
        }
        [HttpPost("home/appointment")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Appointment(AppointmentViewModel model)
        {
            ModelState.Remove("PatientId");
            if (ModelState.IsValid)
            {
                var appointment = new CreateHospitalAppointmentDto
                {
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    HospitalId = model.HospitalId,
                    DepartmentId = model.DepartmentId,
                    AppointmentDate = model.AppointmentDate,
                    AppointmentTime = model.AppointmentTime ?? TimeSpan.Zero,
                };
                var result = await _appointmentService.CreateAppointmentAsync(appointment);
                if (result)
                {
                    TempData["SuccessMessage"] = "Randevunuz başarıyla oluşturuldu.";
                    return RedirectToAction("Appointment", "Home");
                }
                ModelState.AddModelError("", "Seçilen saatte randevu dolu.");
            }
            return View(model);
        }

        [HttpGet("home/active")]
        public async Task<IActionResult> Active()
        {
            var appointments = await _appointmentService.GetPatientAppointmentsAsync("f2a86008-3066-4168-bd1f-6e5d6909def0", false);
            return View(appointments);
        }
        public IActionResult Message()
        {
            return View();
        }
        public IActionResult Past()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Json(cities);
        }
        [HttpGet]
        public async Task<JsonResult> GetHospitals(string cityId)
        {
            var hospitals = await _hospitalService.GetHospitalsByCityAsync(cityId);
            return Json(hospitals);
        }

        // Hastaneye göre bölümleri getir
        [HttpGet]
        public async Task<JsonResult> GetDepartments(string hospitalId)
        {
            var departments = await _departmentService.GetDepartmentsByHospitalAsync(hospitalId);
            return Json(departments);
        }

        // Bölüme göre doktorları getir
        [HttpGet]
        public async Task<JsonResult> GetDoctors(string departmentId)
        {
            var doctors = await _doctorService.GetDoctorsByDepartmentAsync(departmentId);
            return Json(doctors);
        }

        // Doktor ve tarihe göre saatleri getir (Senin yazdığın metod)
        [HttpGet]
        public async Task<JsonResult> GetSlots(string doctorId, DateTime date)
        {
            var slots = await _appointmentService.GetAllSlotsAsync(doctorId, date);
            return Json(slots);
        }

    }
}
