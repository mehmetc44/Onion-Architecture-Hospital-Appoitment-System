using System;
using Microsoft.AspNetCore.Identity;
namespace Appointment.Domain.Entities.Identity;
public class AspUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public Doctor? Doctor { get; set; } 
}
