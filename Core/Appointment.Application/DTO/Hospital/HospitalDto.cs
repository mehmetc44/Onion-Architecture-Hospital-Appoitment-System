using System;

namespace Appointment.Application.DTO.Hospital;

public class HospitalDto
{
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}
