using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
