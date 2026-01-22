using Appointment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Appointment.Persistence.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            optionsBuilder.UseSqlite("Data Source=db/appointment.db", b =>
                b.MigrationsAssembly("Appointment.Persistence"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
