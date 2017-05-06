using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAWs.DTOs
{
    [AutoMap(typeof(DividingPlanHeader))]
    public class CreateDividingPlanHeaderDto : FullAuditedEntity<Guid>
    {
       
        public Guid StyleId { get; set; }

        public string LineNo { get; set; }

        public int TotalEmployee { get; set; }

        public int Target { get; set; }

        public int ProductionPerHour { get; set; }

        public string Remark { get; set; }
    }
}
