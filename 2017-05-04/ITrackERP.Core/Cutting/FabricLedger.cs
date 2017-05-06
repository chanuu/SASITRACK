using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Cutting
{
   public class FabricLedger : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string MarkerNo { get; set; }

        public virtual string RollNo { get; set; }

        public virtual double NotedLength { get; set; }

        public virtual string Type { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual double MarkerLength { get; set; }

        public virtual int NoOfFlys { get; set; }

        public virtual double FabricUsed { get; set; }


        public virtual double NotedBalance { get; set; }

        public virtual double ActualBalance { get; set; }

        public virtual string StyleNo { get; set; }

       
    }
}
