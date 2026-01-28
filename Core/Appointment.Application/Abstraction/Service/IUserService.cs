using System;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;

namespace Appointment.Application.Abstraction.Service;

public interface IUserService
{
    
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
        Task<List<string>> GetRolesFromUserAsync(string userIdOrName);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
}
