using System;
using Appointment.Application.DTO.Hospital;
using Appointment.Domain.Entities;

namespace Appointment.Application.Abstraction.Service;

public interface IHospitalService
{
    Task<List<HospitalDto>> GetAllHospitalsAsync();
    Task<HospitalDto> GetHospitalByIdAsync(string id);
    Task<List<HospitalDto>> GetHospitalsByCityAsync(string name);
    /*Task<HospitalDto> CreateHospitalAsync(HospitalCreateDto hospitalCreateDto);
    Task<HospitalDto> UpdateHospitalAsync(string id, HospitalUpdateDto hospitalUpdateDto);
    Task<bool> DeleteHospitalAsync(string id);*/

}
