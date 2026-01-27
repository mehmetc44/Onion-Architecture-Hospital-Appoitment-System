namespace Appointment.Application.DTO;

public class LoginDTO
{
    public string UserNameOrEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
}
