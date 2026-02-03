using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.Hospital;
using Appointment.Application.Repositories.Hospital;

namespace Appointment.Infrastructure.Services;

public class HospitalService : IHospitalService
{
    IHospitalReadRepository _hospitalRepository;
    IHospitalWriteRepository hospitalWriteRepository;
    public HospitalService(IHospitalReadRepository hospitalReadRepository, IHospitalWriteRepository hospitalWriteRepository)
    {
        _hospitalRepository = hospitalReadRepository;
        this.hospitalWriteRepository = hospitalWriteRepository;
    }
    public Task<List<HospitalDto>> GetAllHospitalsAsync()
    {
        var AllHospitals = _hospitalRepository.GetAll(tracking: false)
            .Select(h => new HospitalDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address
            });
        return Task.FromResult(AllHospitals.ToList());
    }

    public Task<List<HospitalDto>> GetHospitalsByCityAsync(string CityId)
    {
        var hospitals = _hospitalRepository.GetWhere(h => h.CityId == CityId, tracking: false)
            .Select(h => new HospitalDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address
            })
            .ToList();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return Task.FromResult(hospitals);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }

    public Task<HospitalDto> GetHospitalByIdAsync(string id)
    {
        var hospital = _hospitalRepository.GetWhere(h => h.Id == id, tracking: false)
            .Select(h => new HospitalDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address
            })
            .FirstOrDefault();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return Task.FromResult(hospital);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }
}
