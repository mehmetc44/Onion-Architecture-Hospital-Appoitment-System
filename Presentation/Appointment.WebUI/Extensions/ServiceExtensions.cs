using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Domain.Entities.Identity;
using Appointment.Persistence.Context;
using Appointment.Persistence.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        services.AddIdentity<AspUser, AspRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}
