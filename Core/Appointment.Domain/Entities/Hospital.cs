using System;
using Appointment.Domain.Entities.Common;

namespace Appointment.Domain.Entities;

public class Hospital : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public string CityId { get; set; } = null!; 
    public City City { get; set; } = null!;

    public ICollection<Department> Departments { get; set; } = new List<Department>();
}

