using System;
using Appointment.Application.Repositories.HospitalAppointment;
using Appointment.Persistence.Context;

namespace Appointment.Persistence.Repositories.HospitalAppointment;

public class HospitalAppointmentReadRepository: ReadRepository<Domain.Entities.HospitalAppointment>, IHospitalAppointmentReadRepository
{
    public HospitalAppointmentReadRepository(AppDbContext context) : base(context)
    {
    }

}
