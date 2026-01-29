using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;

    public string HospitalId { get; set; } = null!;
    public Hospital Hospital { get; set; } = null!;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}

