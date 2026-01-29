using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Appointment.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<AspUser> _userManager;

    public UserService(UserManager<AspUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO dto)
    {
        var user = new AspUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.TCKimlikNo,
            NormalizedUserName = dto.TCKimlikNo.ToUpper(),
            Email = dto.Email,
            NormalizedEmail = dto.Email.ToUpper(),
            EmailConfirmed = true,
            DateOfBirth = dto.DateOfBirth,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, Appointment.Domain.Consts.Roles.User);
        }
        
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

}
