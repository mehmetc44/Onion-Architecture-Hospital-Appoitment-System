using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Appointment.Persistence.Service;

public class UserService : IUserService
{
    private readonly UserManager<AspUser> _userManager;

    public UserService(UserManager<AspUser> userManager)
    {
        _userManager = userManager;
    }

    public int TotalUsersCount => throw new NotImplementedException();

    public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO dto)
    {
        var user = new AspUser
        {
            UserName = dto.TCKimlikNo,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        return new CreateUserResponseDTO { Succeeded = result.Succeeded, Message = result.Succeeded ? "Kullanıcı başarıyla oluşturuldu." : string.Join("; ", result.Errors.Select(e => e.Description)) };
    }

    public async Task<List<string>> GetRolesFromUserAsync(string userIdOrName)
    {
        AspUser? user = await _userManager.FindByIdAsync(userIdOrName)
            ?? await _userManager.FindByNameAsync(userIdOrName);
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
        else
            return new List<string>();

    }

    public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRefreshTokenAsync(string refreshToken, AspUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
    {
        throw new NotImplementedException();
    }
}
