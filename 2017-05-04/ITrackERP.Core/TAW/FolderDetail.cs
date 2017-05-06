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
    public class FolderDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("OperationPoolId")]

        public virtual OperationPool OperationPool { get; set; }
        public virtual Guid OperationPoolId { get; set; }
        public virtual string FolderType { get; set; }
        public virtual string Remark { get; set; }

        public static FolderDetail Create(string folderType, string remark)
        {
            var @folderdetail = new FolderDetail
            {
                Id = Guid.NewGuid(),
                FolderType = folderType,
                Remark = remark,
            };

            return @folderdetail;
        }
    }
}

