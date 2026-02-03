using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Application.DTO.City;
using Appointment.Application.DTO.HospitalAppoitment;
using Appointment.WebUI.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Appointment.WebUI.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IHospitalService _hospitalService;
        private readonly IDoctorService _doctorService;
        private readonly IHospitalAppointmentService _hospitalAppointmentService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly IAuthService _authService;

        public HomeController(
            ICityService cityService,
            IHospitalService hospitalService,
            IDoctorService doctorService,
            IHospitalAppointmentService hospitalAppointmentService,
            IDepartmentService departmentService,
            IUserService userService, IAuthService authService)
        {
            _cityService = cityService;
            _departmentService = departmentService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _authService = authService;
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
            var userId = _authService.GetActiveUserId();
            if (ModelState.IsValid)
            {
                var appointment = new CreateHospitalAppointmentDto
                {
                    PatientId = userId,
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
            var userId = _authService.GetActiveUserId();
            var appointments = await _hospitalAppointmentService.GetAppointmentsAsync(userId, false);
            return View(appointments);
        }
        [HttpGet("home/past")]
        public async Task<IActionResult> Past()
        {
            var userId = _authService.GetActiveUserId();
            var appointments = await _hospitalAppointmentService.GetAppointmentsAsync(userId, true);
            return View(appointments);
        }
        [HttpGet("home/profile")]
        public IActionResult Profile()
        {
            var userId = _authService.GetActiveUserId();
            var user = _userService.GetUserInformationByIdAsync(userId).Result;
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
