using Appointment.Domain.Entities;
using Appointment.Domain.Entities.Identity;
using Appointment.Domain.Enums;
using Appointment.Persistence.Context;
using Appointment.Domain.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Appointment.Infrastructure.Services
{
    public class SeedService
    {
        private static readonly string[] DoctorFirstNames = { "Ahmet", "Mehmet", "Ayşe", "Fatma", "Ali", "Zeynep", "Emre", "Merve" };
        private static readonly string[] DoctorLastNames = { "Yılmaz", "Kara", "Demir", "Çelik", "Koç", "Öztürk", "Arslan", "Güneş" };

        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AspRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Database migrate ediliyor...");
                await context.Database.MigrateAsync();

                await SeedRoles(roleManager);
                await SeedCities(context);
                await SeedHospitals(context);

                var admin = await SeedAdminUser(userManager);
                var patient = await SeedPatientUser(userManager);

                await SeedDepartmentsAndDoctors(context, userManager);

                await SeedAppointment(context, patient);

                logger.LogInformation("Seed işlemi başarıyla tamamlandı.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Seed sırasında hata oluştu.");
            }
        }

        // ---------------- ROLES ----------------
        private static async Task SeedRoles(RoleManager<AspRole> roleManager)
        {
            await AddRoleAsync(roleManager, Roles.User);
            await AddRoleAsync(roleManager, Roles.Doctor);
            await AddRoleAsync(roleManager, Roles.Admin);
        }

        private static async Task AddRoleAsync(RoleManager<AspRole> roleManager, string roleName)
        {
            if (await roleManager.RoleExistsAsync(roleName)) return;
            await roleManager.CreateAsync(new AspRole { Name = roleName });
        }

        // ---------------- USERS ----------------
        private static async Task<AspUser> SeedAdminUser(UserManager<AspUser> userManager)
        {
            const string email = "admin@example.com";
            var user = await userManager.FindByEmailAsync(email);
            if (user != null) return user;

            user = new AspUser
            {
                FirstName = "Mehmet",
                LastName = "Admin",
                UserName = "00000000000",
                Email = email,
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1990, 1, 1),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await userManager.CreateAsync(user, "!String12345");
            await userManager.AddToRoleAsync(user, Roles.Admin);
            await userManager.AddToRoleAsync(user, Roles.User);

            return user;
        }

        private static async Task<AspUser> SeedDoctorUser(UserManager<AspUser> userManager)
        {
            var rnd = new Random();
            string firstName = DoctorFirstNames[rnd.Next(DoctorFirstNames.Length)];
            string lastName = DoctorLastNames[rnd.Next(DoctorLastNames.Length)];
            string email = $"{firstName.ToLower()}.{lastName.ToLower()}{rnd.Next(1000, 9999)}@example.com";

            var user = await userManager.FindByEmailAsync(email);
            if (user != null) return user;

            user = new AspUser
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = $"{"00000000" + rnd.Next(100, 999)}",
                Email = email,
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1980, 1, 1),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await userManager.CreateAsync(user, "!String12345");
            await userManager.AddToRoleAsync(user, Roles.Doctor);
            await userManager.AddToRoleAsync(user, Roles.User);

            return user;
        }

        private static async Task<AspUser> SeedPatientUser(UserManager<AspUser> userManager)
        {
            const string email = "user@example.com";
            var user = await userManager.FindByEmailAsync(email);
            if (user != null) return user;

            user = new AspUser
            {
                FirstName = "Ayşe",
                LastName = "Hasta",
                UserName = "22222222222",
                Email = email,
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1995, 1, 1),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await userManager.CreateAsync(user, "!String12345");
            await userManager.AddToRoleAsync(user, Roles.User);

            return user;
        }

        // ---------------- CITIES ----------------
        private static async Task SeedCities(AppDbContext context)
        {
            if (context.Cities.Any()) return;

            var cities = new List<string> { "Adana", "Ankara", "İstanbul", "İzmir", "Bursa", "Antalya" };

            context.Cities.AddRange(
                cities.Select(c => new City
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = c
                })
            );

            await context.SaveChangesAsync();
        }

        // ---------------- HOSPITALS ----------------
        private static async Task SeedHospitals(AppDbContext context)
        {
            if (context.Hospitals.Any()) return;

            context.Hospitals.AddRange(
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Merkez Devlet Hastanesi", Address = "Merkez Mah.", CityId = context.Cities.First(c => c.Name == "Ankara").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Ankara Özel Hastanesi", Address = "Atatürk Cad.", CityId = context.Cities.First(c => c.Name == "Ankara").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "İstanbul Devlet Hastanesi", Address = "Taksim Meydanı", CityId = context.Cities.First(c => c.Name == "İstanbul").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Özel Umut Hastanesi", Address = "Kadıköy Cad.", CityId = context.Cities.First(c => c.Name == "İstanbul").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "İzmir Devlet Hastanesi", Address = "Konak Mah.", CityId = context.Cities.First(c => c.Name == "İzmir").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Özel İzmir Hastanesi", Address = "Bornova Cad.", CityId = context.Cities.First(c => c.Name == "İzmir").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Bursa Devlet Hastanesi", Address = "Osmangazi Mah.", CityId = context.Cities.First(c => c.Name == "Bursa").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Özel Bursa Hastanesi", Address = "Nilüfer Cad.", CityId = context.Cities.First(c => c.Name == "Bursa").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Antalya Devlet Hastanesi", Address = "Muratpaşa Mah.", CityId = context.Cities.First(c => c.Name == "Antalya").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Özel Antalya Hastanesi", Address = "Konyaaltı Cad.", CityId = context.Cities.First(c => c.Name == "Antalya").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Adana Devlet Hastanesi", Address = "Seyhan Mah.", CityId = context.Cities.First(c => c.Name == "Adana").Id },
                new Hospital { Id = Guid.NewGuid().ToString(), Name = "Özel Adana Hastanesi", Address = "Çukurova Cad.", CityId = context.Cities.First(c => c.Name == "Adana").Id }
            );

            await context.SaveChangesAsync();
        }

        // ---------------- DEPARTMENTS + DOCTORS ----------------
        private static async Task SeedDepartmentsAndDoctors(AppDbContext context, UserManager<AspUser> userManager)
        {
            if (await context.Departments.AnyAsync()) return;

            var hospitals = await context.Hospitals.ToListAsync();
            var departmentNames = new[] { "Dermatoloji", "Göz Hastalıkları", "Kulak Burun Boğaz", "Kardiyoloji", "Ortopedi" };
            var rnd = new Random();

            foreach (var hospital in hospitals)
            {
                int deptCount = rnd.Next(1, 3);
                var selectedDepartments = departmentNames.OrderBy(x => rnd.Next()).Take(deptCount).ToList();

                foreach (var deptName in selectedDepartments)
                {
                    var department = new Department
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = deptName,
                        HospitalId = hospital.Id
                    };
                    context.Departments.Add(department);

                    var doctorUser = await SeedDoctorUser(userManager);

                    var doctor = new Doctor
                    {
                        Id = Guid.NewGuid().ToString(), // Doktorun kendi biricik ID'si
                        UserId = doctorUser.Id,         // Identity tarafındaki User ile bağımız
                        DepartmentId = department.Id
                        // UserName alanını buradan kaldırdık çünkü o AspUser'da var.
                    };
                    context.Doctors.Add(doctor);
                }
            }
            await context.SaveChangesAsync();
        }


        // ---------------- APPOINTMENT ----------------
        private static async Task SeedAppointment(AppDbContext context, AspUser patient)
        {
            if (await context.Appointments.AnyAsync()) return;

            // SQLite için en güvenli rastgele doktor çekme yöntemi
            var doctor = await context.Doctors
                                      .Include(d => d.Department)
                                      .ThenInclude(dep => dep.Hospital)
                                      .OrderBy(x => EF.Functions.Random())
                                      .FirstOrDefaultAsync();

            if (doctor != null && doctor.Department != null)
            {
                context.Appointments.Add(new HospitalAppointment
                {
                    Id = Guid.NewGuid().ToString(),
                    AppointmentDate = new DateTime(2026, 2, 20),
                    AppointmentTime = new TimeSpan(10, 30, 0),
                    Status = AppointmentStatus.Active,

                    PatientId = patient.Id,   
                    DoctorId = doctor.Id,     
                    DepartmentId = doctor.DepartmentId,
                    HospitalId = doctor.Department.HospitalId
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
