using Appointment.Application.Abstraction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebUI.Controllers
{
    public class HospitalAppointmentController : Controller
    {

        private readonly ICityService _cityService;
        private readonly IHospitalService _hospitalService;
        private readonly IDoctorService _doctorService;
        private readonly IHospitalAppointmentService _hospitalAppointmentService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;

        public HospitalAppointmentController(
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Doctor")]
        public async Task<IActionResult> RescheduleAppointment(string appointmentId, DateTime newDate, TimeSpan newTime)
        {
            try
            {
                var result = await _hospitalAppointmentService.RescheduleAppointmentAsync(appointmentId, newDate, newTime);

                if (result)
                    TempData["SuccessMessage"] = "Randevu başarıyla ertelendi.";
                else
                    TempData["ErrorMessage"] = "Randevu ertelenemedi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata: " + ex.Message;
            }

            return RedirectToAction("Active", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Doctor")]
        public async Task<IActionResult> CancelAppointment(string id)
        {
            try
            {
                var result = await _hospitalAppointmentService.CancelAppointmentAsync(id);

                if (result)
                    TempData["SuccessMessage"] = "Randevu başarıyla iptal edildi.";
                else
                    TempData["ErrorMessage"] = "İptal işlemi başarısız oldu.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata: " + ex.Message;
            }

            return RedirectToReferer();
        }
        [Authorize(Roles = "User,Doctor")]
        private IActionResult RedirectToReferer()
        {
            if (User.IsInRole("Doctor"))
            {
                return RedirectToAction("Dashboard", "Doctor");
            }else if (User.IsInRole("User"))
            {
                return RedirectToAction("Active", "Home");
            }

            return RedirectToAction("Login", "Auth");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CompleteAppointment(string appointmentId, DateTime? currentDate)
        {
            try
            {
                await _hospitalAppointmentService.CompleteAppointmentAsync(appointmentId);
                TempData["SuccessMessage"] = "Randevu tamamlandı.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Hata: " + ex.Message;
            }
            return RedirectToReferer();
        }
    }
}
