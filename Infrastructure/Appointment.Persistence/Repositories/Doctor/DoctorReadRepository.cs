using System;
using Appointment.Application.Repositories.Doctor;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Doctor;

public class DoctorReadRepository : ReadRepository<Domain.Entities.Doctor>, IDoctorReadRepository
{
    public DoctorReadRepository(AppDbContext context) : base(context)
    {
    }
}
