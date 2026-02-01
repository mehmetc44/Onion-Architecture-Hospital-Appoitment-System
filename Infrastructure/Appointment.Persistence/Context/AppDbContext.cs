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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HospitalAppointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>()
        .HasOne(d => d.User)         // Doctor'un bir User'ı var
        .WithOne(u => u.Doctor)      // User'ın bir Doctor'u var
        .HasForeignKey<Doctor>(d => d.UserId) // Foreign Key Doctor tablosundaki UserId'dir
        .OnDelete(DeleteBehavior.Cascade);    // User silinirse Doctor da silinsin (isteğe bağlı)

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}