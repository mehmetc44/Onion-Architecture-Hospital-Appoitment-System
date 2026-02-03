using System;

namespace Appointment.Domain.Entities.Common;

    public class BaseEntity
    {
        public String Id { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
    }