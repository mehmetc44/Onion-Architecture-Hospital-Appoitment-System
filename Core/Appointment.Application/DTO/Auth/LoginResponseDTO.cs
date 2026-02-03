namespace Appointment.Application.DTO;

public class LoginResponseDTO
{
    public bool Succeeded { get; set; }
    public string Message { get; set; } = null!;
}
