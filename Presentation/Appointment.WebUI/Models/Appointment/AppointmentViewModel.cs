using System;

namespace Appointment.WebUI.Models.Appointment;

using System.ComponentModel.DataAnnotations;
using global::Appointment.Application.DTO.City;

public class AppointmentViewModel
{
    public string HospitalId { get; set; }
    public string DepartmentId { get; set; }
    public string DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan? AppointmentTime { get; set; }
    public string PatientId { get; set; }
    public string CityId { get; set; }
}
