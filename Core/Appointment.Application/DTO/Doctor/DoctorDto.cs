using System;

namespace Appointment.Application.DTO.Doctor;

public class DoctorDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DepartmentId { get; set; } = null!;
    public string Id { get; set; } = null!;
}
