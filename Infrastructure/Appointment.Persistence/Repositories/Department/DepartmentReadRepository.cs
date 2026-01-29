using System;
using Appointment.Application.Repositories.Department;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Department;

public class DepartmentReadRepository : ReadRepository<Domain.Entities.Department>, IDepartmentReadRepository
{
    public DepartmentReadRepository(AppDbContext context) : base(context)
    {
    }
}
