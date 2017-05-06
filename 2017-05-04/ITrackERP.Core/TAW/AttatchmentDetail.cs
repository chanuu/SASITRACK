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
    public class AttatchmentDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string AttatchmentType { get; set; }
        public virtual string Remark { get; set; }

        public static AttatchmentDetail Create(string attatchmentType, string remark)
        {
            var @attatchmentDetail = new AttatchmentDetail
            {
                Id = Guid.NewGuid(),
                AttatchmentType = attatchmentType,
                Remark = remark,
            };

            return @attatchmentDetail;
        }
    }
}


