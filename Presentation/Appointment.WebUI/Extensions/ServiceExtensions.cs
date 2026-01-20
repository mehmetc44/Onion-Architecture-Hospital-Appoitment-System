using System;
using Appointment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Appointment.WebUI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSQLiteConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Project.Persistence")
            )
        );
    }
}
