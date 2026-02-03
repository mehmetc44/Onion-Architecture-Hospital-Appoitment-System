using System;
using Appointment.Application.DTO.City;

namespace Appointment.Application.Abstraction.Service;

public interface ICityService
{
    Task<List<CityDto>> GetAllCitiesAsync();
    Task<CityDto> GetCityByIdAsync(string id);
    Task<CityDto> GetCityByNameAsync(string name);
    Task<CityDto> GetCityByHospitalIdAsync(string hospitalId);
}
