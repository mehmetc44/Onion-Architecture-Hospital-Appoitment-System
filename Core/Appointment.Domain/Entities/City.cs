using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Hospital>? Hospitals { get; set; }
}

