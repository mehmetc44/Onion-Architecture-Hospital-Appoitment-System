using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class City 
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<Hospital>? Hospitals { get; set; }
}

