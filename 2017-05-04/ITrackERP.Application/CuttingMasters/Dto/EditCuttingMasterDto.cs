using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Company;

namespace ITrackERP.CuttingMasters.Dto
{
    [AutoMap(typeof(CuttingMaster))]
    public class EditCuttingMasterDto : FullAuditedEntityDto<Guid>
    {
        public string CuttingMasterNo { get; set; }

        public string ItemType { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public string Style { get; set; }
    }
}
