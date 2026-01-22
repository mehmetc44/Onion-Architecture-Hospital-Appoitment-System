using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Appointment.Domain.Entities.Identity;

namespace Appointment.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<AspRole>
{
    public void Configure(EntityTypeBuilder<AspRole> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).HasMaxLength(256);
        builder.Property(r => r.NormalizedName).HasMaxLength(256);
        builder.HasData(
            new AspRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new AspRole { Id = "2", Name = "Doctor", NormalizedName = "DOCTOR" },
            new AspRole { Id = "3", Name = "User", NormalizedName = "USER" }
        );
    }
}