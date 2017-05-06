using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITRACK.Costing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Orders.Dto
{
    [AutoMap(typeof(WorkOrderRatio))]
    public class CreateWorkOrderRatioDto: FullAuditedEntity<Guid>
    {

        public  string Color { get; set; }

        public  string Size { get; set; }

        public  string Length { get; set; }

        public  int Quantity { get; set; }
    }
}
