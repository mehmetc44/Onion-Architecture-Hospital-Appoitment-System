using System;
using Appointment.Application.DTO.Hospital;
using Appointment.Domain.Entities;

namespace Appointment.Application.Abstraction.Service;

public interface IDepartmentService
{
    Task<List<Department>> GetDepartmentsByHospitalAsync(string hospitalId);

}
