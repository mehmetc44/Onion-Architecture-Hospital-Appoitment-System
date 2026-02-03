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
    }
}