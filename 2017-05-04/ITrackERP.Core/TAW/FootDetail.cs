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
    public class FootDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string FootType { get; set; }
        public virtual string Remark { get; set; }

        public static FootDetail Create(string footType, string remark)
        {
            var @footdetail = new FootDetail
            {
                Id = Guid.NewGuid(),
                FootType = footType,
                Remark = remark,
            };

            return @footdetail;
        }
    }
}


