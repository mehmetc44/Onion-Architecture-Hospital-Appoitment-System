using System;
using Appointment.Application.DTO;
using Appointment.Application.DTO.Auth;

namespace Appointment.Application.Abstraction.Service;

public interface IAuthService
{
    Task<LoginResponseDTO> LoginAsync(LoginDTO dto,int accessTokenLifeTime);
    Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}
