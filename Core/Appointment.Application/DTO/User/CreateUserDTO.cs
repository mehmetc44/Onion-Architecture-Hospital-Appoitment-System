using System;

namespace Appointment.Application.DTO;

public class CreateUserDTO
{

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string TCKimlikNo { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}
