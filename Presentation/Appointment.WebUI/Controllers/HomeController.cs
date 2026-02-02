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
        private readonly IHospitalAppointmentService _hospitalAppointmentService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;

        public HomeController(
            ICityService cityService,
            IHospitalService hospitalService,
            IDoctorService doctorService,
            IHospitalAppointmentService hospitalAppointmentService,
            IDepartmentService departmentService,
            IUserService userService)
        {
            _cityService = cityService;
            _departmentService = departmentService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _userService = userService;
            _hospitalAppointmentService = hospitalAppointmentService;
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
                var result = await _hospitalAppointmentService.CreateAppointmentAsync(appointment);
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
            var appointments = await _hospitalAppointmentService.GetAppointmentsAsync("f2a86008-3066-4168-bd1f-6e5d6909def0", false);
            return View(appointments);
        }
        public IActionResult Message()
        {
            return View();
        }
        public async Task<IActionResult> Past()
        {
            var appointments = await _hospitalAppointmentService.GetAppointmentsAsync("f2a86008-3066-4168-bd1f-6e5d6909def0", true);
            return View(appointments);
        }

        public IActionResult Profile()
        {
            var user = _userService.GetUserInformationByIdAsync("f2a86008-3066-4168-bd1f-6e5d6909def0").Result;
            return View(user);
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
        [HttpGet]
        public async Task<JsonResult> GetDepartments(string hospitalId)
        {
            var departments = await _departmentService.GetDepartmentsByHospitalAsync(hospitalId);
            return Json(departments);
        }
        [HttpGet]
        public async Task<JsonResult> GetDoctors(string departmentId)
        {
            var doctors = await _doctorService.GetDoctorsByDepartmentAsync(departmentId);
            return Json(doctors);
        }

        [HttpGet]
        public async Task<JsonResult> GetSlots(string doctorId, DateTime date)
        {
            var slots = await _doctorService.GetAllSlotsAsync(doctorId, date);
            return Json(slots);
        }

    }
}
