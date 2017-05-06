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
    public class NeedleDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string NeedleType { get; set; }
        public virtual string Remark { get; set; }

        public static NeedleDetail Create(string needleType, string remark)
        {
            var @needledetail = new NeedleDetail
            {
                Id = Guid.NewGuid(),
                NeedleType = needleType,
                Remark = remark,
            };

            return @needledetail;
        }
    }
}


