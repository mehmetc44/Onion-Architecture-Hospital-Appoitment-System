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

            var dto = new CreateUserDTO{
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new LoginDTO
            {
                UserNameOrEmail = model.UserNameOrEmail,
                Password = model.Password
            };

            try
            {
                var result = await _authService.LoginAsync(dto, 1);

                if (result.Succeeded)
                {
                    Response.Cookies.Append("token", result.Token!, 
                        new Microsoft.AspNetCore.Http.CookieOptions 
                        { 
                            HttpOnly = true, 
                            Secure = true,
                            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                            Expires = DateTimeOffset.UtcNow.AddHours(1)
                        });
                    Response.Cookies.Append("refreshToken", result.RefreshToken!, 
                        new Microsoft.AspNetCore.Http.CookieOptions 
                        { 
                            HttpOnly = true, 
                            Secure = true,
                            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                            Expires = DateTimeOffset.UtcNow.AddDays(7)
                        });
                    
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", result.Message ?? "Giriş yapılırken bir hata oluştu.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message ?? "Giriş yapılırken bir hata oluştu.");
            }
            
            return View(model);
        }
    }
}
