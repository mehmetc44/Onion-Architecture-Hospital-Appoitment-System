using System;
using System.Text;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO;
using Appointment.Domain.Entities.Identity;
using Appointment.Persistence.Context;
using Appointment.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Appointment.WebUI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSQLiteConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("SQLite"),
                b => b.MigrationsAssembly("Appointment.Persistence")
            )
        );
    }
    public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AspUser, AspRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

    }
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}
