using Appointment.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Appointment.Application.DTO;
using Appointment.Application.Abstraction.Service;

namespace Appointment.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new CreateUserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TCKimlikNo = model.TCKimlikNo,
                Email = model.Email,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth
            };

            var result = await _userService.CreateAsync(dto);

            if (result.Succeeded) return RedirectToAction("Login");

            ModelState.AddModelError("", result.Message ?? "Kullanıcı oluşturulurken bir hata oluştu.");
            return View(model);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!model.SelectedRole.HasValue)
            {
                ModelState.AddModelError("", "Lütfen bir rol seçiniz.");
                return View(model);
            }

            var dto = new LoginDTO
            {
                UserNameOrEmail = model.UserNameOrEmail,
                Password = model.Password,
                SelectedRole = model.SelectedRole
            };

            var result = await _authService.LoginAsync(dto);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Message ?? "Giriş başarısız.");
                return View(model);
            }

            return model.SelectedRole.Value switch
            {
                Appointment.Domain.Enums.UserRole.Admin
                    => RedirectToAction("Index", "Admin"),

                Appointment.Domain.Enums.UserRole.Doctor
                    => RedirectToAction("Index", "Doctor"),

                _ => RedirectToAction("Appointment", "Home")
            };
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
