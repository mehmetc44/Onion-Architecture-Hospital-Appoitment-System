namespace Appointment.Application.DTO;

public class LoginResponseDTO
{
    public bool Succeeded { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string Message { get; set; } = null!;
}
