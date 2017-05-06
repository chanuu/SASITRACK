using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITRACK.Costing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Orders.Dto
{
    [AutoMap(typeof(WorkOrderHeader))]
    public class CreateWorkOrderDto
    {
        [Required]
        public string WorkOrderNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string Remark { get; set; }

        public string StyleNo { get; set; }

        public virtual Guid StyleId { get; set; }

    }
}
