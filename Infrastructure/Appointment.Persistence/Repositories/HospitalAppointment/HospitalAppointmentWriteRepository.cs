using System;
using Appointment.Application.Repositories.HospitalAppointment;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.HospitalAppointment;

public class HospitalAppointmentWriteRepository : WriteRepository<Domain.Entities.HospitalAppointment>, IHospitalAppointmentWriteRepository
{
    public HospitalAppointmentWriteRepository(AppDbContext context) : base(context)
    {
    }
}

