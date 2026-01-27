using System;
using System.Security.Claims;
using Appointment.Application.DTO.Auth;

namespace Appointment.Application.Abstraction.Service;

public interface ITokenService
{
    public TokenDto CreateAccessToken(int minute, List<Claim> claims);
    public string CreateRefreshToken();
}
