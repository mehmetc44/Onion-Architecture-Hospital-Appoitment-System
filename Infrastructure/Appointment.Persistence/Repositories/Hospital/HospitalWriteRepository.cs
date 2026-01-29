using System;
using Appointment.Application.Repositories.Hospital;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Hospital;

public class HospitalWriteRepository : WriteRepository<Domain.Entities.Hospital>, IHospitalWriteRepository
{
    public HospitalWriteRepository(AppDbContext context) : base(context)
    {
    }
}
