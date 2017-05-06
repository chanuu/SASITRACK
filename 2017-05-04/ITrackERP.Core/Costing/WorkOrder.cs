using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System.Collections.ObjectModel;

namespace ITRACK.Costing
{
    public class WorkOrderHeader : FullAuditedEntity<Guid>,IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

    
        public virtual int TenantId { get; set; }

        public virtual string WorkOrderNo { get; set; }


        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }
        public virtual string PoNo { get; set; }

        [Required]
        public virtual DateTime StartDate { get; set; }

        [Required]
        public virtual DateTime EndDate { get; set; }

        public virtual string Status { get; set; }

        public virtual string Priority { get; set; }

        public virtual string Remark { get; set; }

       
        public virtual ICollection<WorkOrderRatio> WorkOrderRatios { get; set; }


        public static WorkOrderHeader Create(int tenantId, string workOrderNo, DateTime startDate, DateTime endDate,
            string status, string priority, string remark, Guid styleId,string styleNo)
        {
            var @workorder = new WorkOrderHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                WorkOrderNo = workOrderNo,
                StartDate = startDate,
                EndDate = endDate,
                Status = status,
                Priority = priority,
                Remark = remark,
                StyleId = styleId,
                StyleNo = styleNo

            };

            @workorder.WorkOrderRatios = new Collection<WorkOrderRatio>();
            return @workorder;
        }

    }
}
