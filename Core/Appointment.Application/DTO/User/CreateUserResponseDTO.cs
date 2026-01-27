using System;

namespace Appointment.Application.DTO;

public class CreateUserResponseDTO
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    
}
