using System;
using Appointment.Application.DTO.Doctor;

namespace Appointment.Application.Abstraction.Service;

public interface IDoctorService
{
    Task<List<DoctorDto>> GetDoctorsByDepartmentAsync(string departmentId);
    Task<DoctorDto> GetDoctorByIdAsync(string id);
    
}
