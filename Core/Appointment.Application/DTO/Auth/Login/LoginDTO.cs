namespace Appointment.Application.DTO;

using Appointment.Domain.Enums;

public class LoginDTO
{
    public string UserNameOrEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole? SelectedRole { get; set; }
}
