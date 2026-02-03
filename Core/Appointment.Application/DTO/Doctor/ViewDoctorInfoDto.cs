using System;

namespace Appointment.Application.DTO.Doctor;

public class ViewDoctorInfoDto
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string HospitalName { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}
