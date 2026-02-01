using System;

namespace Appointment.Application.Repositories.City;

public interface ICityReadRepository : IReadRepository<Domain.Entities.City>
{
    Task<Domain.Entities.City> GetCityByHospitalIdAsync(string hospitalId);
}
