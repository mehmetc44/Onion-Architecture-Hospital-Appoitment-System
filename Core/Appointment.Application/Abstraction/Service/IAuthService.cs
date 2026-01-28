using System;
using Appointment.Application.DTO;
using Appointment.Application.DTO.Auth;
using Appointment.Domain.Entities.Identity;

namespace Appointment.Application.Abstraction.Service;

public interface IAuthService
{
    Task<LoginResponseDTO> LoginAsync(LoginDTO dto);
    Task LogoutAsync();
}
