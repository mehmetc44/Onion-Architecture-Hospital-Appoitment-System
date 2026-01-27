using System;

namespace Appointment.Application.DTO.Auth;

public class TokenDto
{
        public string AccessToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string? RefreshToken { get; set; }
}
