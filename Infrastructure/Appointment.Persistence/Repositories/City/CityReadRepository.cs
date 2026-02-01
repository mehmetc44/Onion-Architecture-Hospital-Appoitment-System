using System;
using Appointment.Application.Repositories.City;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.City;

public class CityReadRepository : ReadRepository<Domain.Entities.City>, ICityReadRepository
{
    public CityReadRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Domain.Entities.City> GetCityByHospitalIdAsync(string hospitalId)
    {
        var city = Table
            .FirstOrDefault(c => c.Hospitals.Any(h => h.Id == hospitalId));
        return Task.FromResult(city ?? null!);
    }
}
