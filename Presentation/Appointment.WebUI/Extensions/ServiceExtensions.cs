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
using Appointment.Application.Repositories;
using Appointment.Application.Repositories.City;
using Appointment.Persistence.Repositories.City;
using Appointment.Application.Repositories.HospitalAppointment;
using Appointment.Persistence.Repositories.HospitalAppointment;
using Appointment.Application.Repositories.Doctor;
using Appointment.Application.Repositories.Hospital;
using Appointment.Persistence.Repositories.Hospital;
using Appointment.Persistence.Repositories.Doctor;
using Appointment.Application.Repositories.Department;
using Appointment.Persistence.Repositories.Department;

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

    services.AddScoped<ICityService, CityService>();
    services.AddScoped<ICityReadRepository, CityReadRepository>();
    services.AddScoped<ICityWriteRepository, CityWriteRepository>();

    services.AddScoped<IHospitalService, HospitalService>();
    services.AddScoped<IHospitalReadRepository, HospitalReadRepository>(); 
    services.AddScoped<IHospitalWriteRepository, HospitalWriteRepository>();

    services.AddScoped<IDoctorService, DoctorService>();
    services.AddScoped<IDoctorReadRepository, DoctorReadRepository>(); 
    services.AddScoped<IDoctorWriteRepository, DoctorWriteRepository>();

    services.AddScoped<IHospitalAppointmentService, HospitalAppointmentService>();
    services.AddScoped<IHospitalAppointmentReadRepository, HospitalAppointmentReadRepository>(); 
    services.AddScoped<IHospitalAppointmentWriteRepository, HospitalAppointmentWriteRepository>(); 

    services.AddScoped<IDepartmentService, DepartmentService>();
    services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>(); 
    services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
}
}
