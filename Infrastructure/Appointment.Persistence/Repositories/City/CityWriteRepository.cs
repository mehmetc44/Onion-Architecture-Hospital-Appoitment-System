using System;
using Appointment.Application.Repositories.City;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.City;

public class CityWriteRepository : WriteRepository<Domain.Entities.City>, ICityWriteRepository
{
    public CityWriteRepository(AppDbContext context) : base(context)
    {
    }
}
