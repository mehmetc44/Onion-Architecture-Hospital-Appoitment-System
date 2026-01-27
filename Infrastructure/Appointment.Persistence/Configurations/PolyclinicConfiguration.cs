using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Persistence.Configurations
{
    public class PolyclinicConfiguration : IEntityTypeConfiguration<Polyclinic>
    {
        public void Configure(EntityTypeBuilder<Polyclinic> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.Polyclinics)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
