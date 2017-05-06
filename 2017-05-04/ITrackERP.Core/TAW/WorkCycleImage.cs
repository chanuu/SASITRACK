using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class WorkCycleImage : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string WorkCycleImagePath { get; set; }
        public virtual string Remark { get; set; }

        public static WorkCycleImage Create(string workCycleImagePath, string remark)
        {
            var @workCycleImage = new WorkCycleImage
            {
                Id = Guid.NewGuid(),
                WorkCycleImagePath = workCycleImagePath,
                Remark = remark,
            };

            return @workCycleImage;
        }
    }
}

