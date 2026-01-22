using Microsoft.EntityFrameworkCore;
using Appointment.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Appointment.Domain.Entities.Identity;
using Appointment.Persistence.Configurations;

namespace Appointment.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AspUser, AspRole, string>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Polyclinic> Polyclinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HospitalAppointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());  
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}