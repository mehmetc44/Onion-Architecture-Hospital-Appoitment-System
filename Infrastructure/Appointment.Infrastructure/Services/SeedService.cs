using System;
using System.Linq;
using Appointment.Domain.Entities;
using Appointment.Domain.Entities.Identity;
using Appointment.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Appointment.Infrastructure.Services
{
    public class SeedService
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AspRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Initializing database...");
                await context.Database.MigrateAsync();

                await SeedCities(context, logger);
                await SeedUsers(userManager, roleManager, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private static async Task SeedUsers(UserManager<AspUser> userManager, RoleManager<AspRole> roleManager, ILogger logger)
        {
            logger.LogInformation("Creating default roles...");

            await AddRoleAsync(roleManager, "User");
            await AddRoleAsync(roleManager, "Doctor");
            await AddRoleAsync(roleManager, "Admin");

            logger.LogInformation("Creating admin user...");
            var adminEmail = "admin@example.com";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new AspUser
                {
                    FirstName = "Mehmet",
                    LastName = "Admin",
                    UserName = "00000000000",
                    NormalizedUserName = "00000000000",
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    EmailConfirmed = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await userManager.CreateAsync(adminUser, "!String12345");
                if (result.Succeeded)
                {
                    logger.LogInformation("Assigning Admin and User roles to the admin user.");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddToRoleAsync(adminUser, "User");
                }
                else
                {
                    logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedCities(AppDbContext context, ILogger logger)
        {
            if (!context.Cities.Any())
            {
                logger.LogInformation("Seeding cities...");

                var cities = new List<string>
                {
                    "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya",
                    "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
                    "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne",
                    "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
                    "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu",
                    "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
                    "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu",
                    "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
                    "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray",
                    "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır",
                    "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
                };

                cities.Sort();

                var cityEntities = cities.Select(name => new City
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name
                }).ToList();

                context.Cities.AddRange(cityEntities);
                await context.SaveChangesAsync();

                logger.LogInformation("Cities seeded successfully.");
            }
        }

        private static async Task AddRoleAsync(RoleManager<AspRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new AspRole { Name = roleName });
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
