using System;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Appointment.Application.Abstraction.Service;

public interface IUserService
{
    
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
        Task<List<string>> GetRolesFromUserAsync(string userIdOrName);
        Task<ViewUserInfoDto?> GetUserInformationByIdAsync(string id);
}
