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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new LoginDTO
            {
                Email = model.Email,
                Password = model.Password
            };

            var result = await _authService.LoginAsync(dto);

            if (result.Succeeded)
            {
                // Access Token'ı cookie'ye kaydet
                Response.Cookies.Append("token", result.Token!, 
                    new Microsoft.AspNetCore.Http.CookieOptions 
                    { 
                        HttpOnly = true, 
                        Secure = true,
                        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                        Expires = DateTimeOffset.UtcNow.AddHours(1)
                    });

                // Refresh Token'ı cookie'ye kaydet
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
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken()
        {
            var token = Request.Cookies["token"];
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))
                return Unauthorized(new { message = "Token bulunamadı." });

            var dto = new RefreshTokenDTO
            {
                Token = token,
                RefreshToken = refreshToken
            };

            var result = await _authService.RefreshTokenAsync(dto);

            if (result.Succeeded)
            {
                // Yeni token'ları cookie'ye kaydet
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

                return Ok(new { message = "Token yenilendi.", token = result.Token, refreshToken = result.RefreshToken });
            }

            return Unauthorized(new { message = result.Message });
        }
        }
    }
}
