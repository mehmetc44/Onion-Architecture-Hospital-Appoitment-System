using System;
using Appointment.Application.Repositories.Department;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Department;

public class DepartmentWriteRepository : WriteRepository<Domain.Entities.Department>, IDepartmentWriteRepository
{
    public DepartmentWriteRepository(AppDbContext context) : base(context)
    {
    }
}
