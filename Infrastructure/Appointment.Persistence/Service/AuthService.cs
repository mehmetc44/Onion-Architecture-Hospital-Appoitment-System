using System;
using System.Security.Claims;
using System.Text;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Application.DTO.Auth;
using Appointment.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Appointment.Persistence.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<AspUser> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly SignInManager<AspUser> _signInManager;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<AspUser> userManager, IOptions<JwtSettings> jwtSettings, SignInManager<AspUser> signInManager, IUserService userService, ITokenService tokenService)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
        _signInManager = signInManager;
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDTO> LoginAsync(LoginDTO model,int accessTokenLifeTime)
    {
        AspUser? user = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);

            if (user == null)
                return new LoginResponseDTO { Succeeded = false, Message = "Kullanıcı bulunamadı." };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                var roles = await _userService.GetRolesFromUserAsync(user.UserName??user.Id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                TokenDto token = _tokenService.CreateAccessToken(accessTokenLifeTime,claims);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return new LoginResponseDTO
                {
                    Succeeded = true,
                    Token = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    Message = "Giriş başarılı."
                };
            }
            throw new Exception("Giriş başarısız.");
    }
    public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
    {
        AspUser? user = _userManager.Users.FirstOrDefault(b => b.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenExpiryTime > DateTime.UtcNow)
            {
                var roles = await _userService.GetRolesFromUserAsync(user.UserName);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                TokenDto token = _tokenService.CreateAccessToken(15,claims);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 10);
                return token;
            }
            else
                throw new Exception("Geçersiz refresh token.");
    }

    public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
    {
        AspUser? user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                byte[] decodedBytes = WebEncoders.Base64UrlDecode(resetToken);
                string decodedToken = Encoding.UTF8.GetString(decodedBytes);
                return await _userManager.VerifyUserTokenAsync(
                    user,
                    _userManager.Options.Tokens.PasswordResetTokenProvider,
                    "ResetPassword",
                    decodedToken
                );
            }
            return false;
    }
}
