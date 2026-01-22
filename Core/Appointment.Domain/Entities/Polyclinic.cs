using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class Polyclinic: BaseEntity
{
    public string Name { get; set; } = null!;
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; } = null!;
    public ICollection<Doctor> Doctors { get; set; } = null!;
}

