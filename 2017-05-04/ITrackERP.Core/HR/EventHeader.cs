using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.HR
{
    public class EventHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }       
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual string Type { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }

        public virtual string Frequency { get; set; }

        public virtual Nullable<DateTime> ExpectedDate { get; set; }
        public virtual string Department { get; set; }

        public virtual string Venue { get; set; }

        public virtual ICollection<Invitee> Invitees { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public static EventHeader Create(int tenantId, string name, string description, string type, DateTime date, string frequency, DateTime expectedDate, string department, string venue)
        {
            var @event = new EventHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Name = name,
                Description = description,
                Type = type,
                Date = date,
                Frequency = frequency,
                ExpectedDate = expectedDate,
                Department = department,
                Venue = venue
            };

            @event.Invitees = new Collection<Invitee>();
            @event.Albums = new Collection<Album>();
            return @event;



        }
    }
}

