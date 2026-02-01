using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.City;
using Appointment.Application.Repositories.City;
using Appointment.Persistence.Repositories.City;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Services;

public class CityService(ICityReadRepository cityReadRepository) : ICityService
{
    ICityReadRepository _cityReadRepository = cityReadRepository;

    public async Task<List<CityDto>> GetAllCitiesAsync()
    {
        var query = _cityReadRepository.GetAll(tracking: false);
        var cityList = await query.Select(c => new CityDto 
        {
            Id = c.Id,
            Name = c.Name
        })
        .OrderBy(c => c.Name)
        .ToListAsync();
        return cityList;
    }

    public async Task<CityDto> GetCityByHospitalIdAsync(string hospitalId)
    {
        var city = await _cityReadRepository.GetCityByHospitalIdAsync(hospitalId);
        return new CityDto
        {
            Id = city.Id,
            Name = city.Name
        };
    }

    public Task<CityDto> GetCityByIdAsync(string id)
    {
        var city = _cityReadRepository.GetWhere(c => c.Id == id, tracking: false)
            .Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstOrDefault();
        return Task.FromResult(city ?? null!);
    }

    public Task<CityDto> GetCityByNameAsync(string name)
    {
        var city = _cityReadRepository.GetWhere(c => c.Name == name, tracking: false)
            .Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstOrDefault();
        return Task.FromResult(city ?? null!);
    }
}
