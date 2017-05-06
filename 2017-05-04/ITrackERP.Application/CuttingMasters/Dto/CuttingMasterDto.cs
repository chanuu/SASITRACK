using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Company;
using ITrackERP.Styles.Dto;
using ITRACK.Company;

namespace ITrackERP.CuttingMasters.Dto

{
    [AutoMapFrom(typeof(CuttingMaster))]
    public class CuttingMasterDto : FullAuditedEntityDto<Guid>
    {
        public string CuttingMasterNo { get; set; }

        public string ItemType { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public string Style { get; set; }

        public string StyleId { get; set; }

        public virtual bool isCuttingStarted { get; set; }

        public virtual Nullable<DateTime> CuttingStartedDate { get; set; }

        public virtual bool isCuttingFinised { get; set; }

        public virtual Nullable<DateTime> CuttingFinishedDate { get; set; }


        public ICollection<CuttingItemDto> CuttingItems { get; set; }

    }
}
