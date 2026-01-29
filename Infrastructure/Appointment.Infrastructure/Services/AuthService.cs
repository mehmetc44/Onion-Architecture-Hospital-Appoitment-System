using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
namespace Appointment.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AspUser> _userManager;
    private readonly SignInManager<AspUser> _signInManager;
    private readonly IUserService _userService;

    public AuthService(UserManager<AspUser> userManager, SignInManager<AspUser> signInManager, IUserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userService = userService;
    }

    public async Task<LoginResponseDTO> LoginAsync(LoginDTO model)
    {
        //Search User by UserName or Email
        var user = await _userManager.FindByNameAsync(model.UserNameOrEmail)
                   ?? await _userManager.FindByEmailAsync(model.UserNameOrEmail);

        if (user == null)
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "Kullanıcı bulunamadı."
            };
        //Password Check
        var passwordCheck = await _signInManager.CheckPasswordSignInAsync(
            user,
            model.Password,
            lockoutOnFailure: false
        );

        if (!passwordCheck.Succeeded)
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "Kullanıcı adı veya şifre hatalı."
            };

        //Role Check
        if (model.SelectedRole.HasValue)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var selectedRole = model.SelectedRole.Value.ToString();

            if (!roles.Contains(selectedRole))
            {
                return new LoginResponseDTO
                {
                    Succeeded = false,
                    Message = "Bu rolle giriş yapmaya yetkiniz yok."
                };
            }
        }
        //Cookie SignIn
        await _signInManager.SignInAsync(
            user,
            isPersistent: true
        );

        return new LoginResponseDTO
        {
            Succeeded = true,
            Message = "Giriş başarılı."
        };
    }
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
