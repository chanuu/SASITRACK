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
    public class WorkCycleVideo : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string WorkCycleVideoPath { get; set; }
        public virtual string Remark { get; set; }

        public static WorkCycleVideo Create(string workCycleVideoPath, string remark)
        {
            var @workCycleVideo = new WorkCycleVideo
            {
                Id = Guid.NewGuid(),
                WorkCycleVideoPath = workCycleVideoPath,
                Remark = remark,
            };

            return @workCycleVideo;
        }
    }
}


