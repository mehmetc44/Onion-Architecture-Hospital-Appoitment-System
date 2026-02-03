using System;
using Appointment.Application.Abstraction.Service;
using Appointment.Application.Repositories.Department;
using Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Services;

public class DepartmentService : IDepartmentService
{

    IDepartmentWriteRepository _writeDepartmentRepo;
    IDepartmentReadRepository _readDepartmentRepo;
    public DepartmentService(IDepartmentReadRepository readDepartmentRepo, IDepartmentWriteRepository writeDepartmentRepo)
    {
        _readDepartmentRepo = readDepartmentRepo;
        _writeDepartmentRepo = writeDepartmentRepo;
    }

    public async Task<List<Department>> GetDepartmentsByHospitalAsync(string hospitalId)
    {
        return await _readDepartmentRepo.GetAll(tracking: false)
            .Where(x => x.HospitalId == hospitalId)
            .ToListAsync();
    }
}
