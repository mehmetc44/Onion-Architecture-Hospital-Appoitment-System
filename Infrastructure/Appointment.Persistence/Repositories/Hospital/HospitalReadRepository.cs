using System;
using Appointment.Application.Repositories.Hospital;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.Hospital;

public class HospitalReadRepository: ReadRepository<Domain.Entities.Hospital>, IHospitalReadRepository
{
    public HospitalReadRepository(AppDbContext context) : base(context)
    {
    }

}
