using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITrackERP.Company;

namespace ITrackERP.CuttingMasters.Dto
{
    [AutoMap(typeof(CuttingMaster))]
    public class CreateCuttingMasterDto : FullAuditedEntity<Guid>
    {
        public string CuttingMasterNo { get; set; }

        public string ItemType { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }

    }
}
