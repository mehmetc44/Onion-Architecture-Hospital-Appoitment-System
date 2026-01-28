using System;
using System.Security.Claims;
using System.Text;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Appointment.Persistence.Service;

public class TokenService : ITokenService
{
    IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TokenDto CreateAccessToken(int minute, List<Claim> claims)
    {
        TokenDto token = new TokenDto();
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"] ?? throw new ArgumentNullException("JwtSettings:Key")));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        token.Expiration = DateTime.Now.AddMinutes(minute);
        JwtSecurityToken jwtToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            expires: token.Expiration,
            signingCredentials: credentials,
            claims: claims
        );
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        token.AccessToken = tokenHandler.WriteToken(jwtToken);
        token.RefreshToken = CreateRefreshToken();
        return token;
    }


    public string CreateRefreshToken()
    {
        byte[] data = new byte[32];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(data);
        return Convert.ToBase64String(data);
    }


}
