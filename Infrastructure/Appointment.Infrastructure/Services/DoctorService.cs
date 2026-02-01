using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.DTO.Doctor;
using Appointment.Application.Repositories.Doctor;
using Appointment.Domain.Entities;

namespace Appointment.Infrastructure.Services;

public class DoctorService : IDoctorService
{
    IDoctorReadRepository _doctorReadRepository;
    IDoctorWriteRepository _doctorWriteRepository;
    
    public DoctorService(IDoctorReadRepository doctorReadRepository, IDoctorWriteRepository doctorWriteRepository)
    {
        _doctorReadRepository = doctorReadRepository;
        _doctorWriteRepository = doctorWriteRepository;
    }

    public Task<DoctorDto> GetDoctorByIdAsync(string id)
    {
        var doctor = _doctorReadRepository.GetWhere(d => d.Id == id, tracking: false)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                DepartmentId = d.DepartmentId
            })
            .FirstOrDefault();
        return Task.FromResult(doctor);
}

    public Task<List<DoctorDto>> GetDoctorsByDepartmentAsync(string departmentId)
    {
        var doctors = _doctorReadRepository.GetWhere(d => d.DepartmentId == departmentId, tracking: false)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                DepartmentId = d.DepartmentId
            })
            .ToList();
        return Task.FromResult(doctors);
    }

}
