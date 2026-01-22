using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class Hospital : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public int CityId { get; set; }
    public City City { get; set; } = null!;

    public ICollection<Polyclinic> Polyclinics { get; set; } = null!;
}

