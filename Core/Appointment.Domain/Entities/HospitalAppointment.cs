using System;
using Appointment.Domain.Entities.Identity;
using Appointment.Domain.Enums;
using Appointment.Domain.Entities.Common;
namespace Appointment.Domain.Entities;

public class HospitalAppointment : BaseEntity
{
    public HospitalAppointment()
    {
        Id = Guid.NewGuid().ToString();
        Status = AppointmentStatus.Active; 
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public AppointmentStatus Status { get; set; }
    public string PatientId { get; set; } = null!;
    public AspUser Patient { get; set; } = null!;
    public string DoctorId { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public string HospitalId { get; set; } = null!;
    public Hospital Hospital { get; set; } = null!;
    public string DepartmentId { get; set; } = null!;
    public Department Department { get; set; } = null!;
}


