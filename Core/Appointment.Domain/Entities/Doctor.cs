using System;
using Appointment.Domain.Entities.Common;
using Appointment.Domain.Entities.Identity;
namespace Appointment.Domain.Entities;

public class Doctor : BaseEntity
{
    public string UserId { get; set; } = null!;
    public AspUser User { get; set; } = null!;

    public int PolyclinicId { get; set; }
    public Polyclinic Polyclinic { get; set; } = null!;

    public ICollection<HospitalAppointment> Appointments { get; set; } = null!;
}

