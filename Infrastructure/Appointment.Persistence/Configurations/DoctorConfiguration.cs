using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Persistence.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.User)
            .WithOne(u => u.Doctor)   
            .HasForeignKey<Doctor>(d => d.Id)  
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Department)
            .WithMany(dep => dep.Doctors)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
