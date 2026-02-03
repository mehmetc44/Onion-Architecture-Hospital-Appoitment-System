using System;
using Appointment.Application.Repositories.Doctor;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Doctor;

public class DoctorWriteRepository : WriteRepository<Domain.Entities.Doctor>, IDoctorWriteRepository
{
    public DoctorWriteRepository(AppDbContext context) : base(context)
    {
    }
}
