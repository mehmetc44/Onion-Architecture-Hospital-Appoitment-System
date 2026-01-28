using Appointment.Persistence.Context;
using Appointment.Domain.Entities.Identity;
using Appointment.WebUI.Extensions;
using Appointment.Application.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Appointment.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.ConfigureIdentity(builder.Configuration);
            builder.Services.ConfigureSQLiteConnection(builder.Configuration);
            builder.Services.ConfigureDependencyInjection();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // --- Middleware ---
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // --- Route ---
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
