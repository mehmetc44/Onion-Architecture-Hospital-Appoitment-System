using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Appointment.Domain.Entities.Common;
using Appointment.Domain.Entities.Identity;
namespace Appointment.Domain.Entities;


    public class Doctor : BaseEntity
{
    public string UserId { get; set; } = null!;
    public AspUser User { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;
    public Department Department { get; set; } = null!;

    public ICollection<HospitalAppointment> Appointments { get; set; } = new List<HospitalAppointment>();
}



