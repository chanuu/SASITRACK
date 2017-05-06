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
    public class ThreadDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string ThreadType { get; set; }
        public virtual string Remark { get; set; }

        public static ThreadDetail Create(string threadType, string remark)
        {
            var @threaddetail = new ThreadDetail
            {
                Id = Guid.NewGuid(),
                ThreadType = threadType,
                Remark = remark,
            };

            return @threaddetail;
        }
    }
}
