using System;
using Appointment.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Application.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}

