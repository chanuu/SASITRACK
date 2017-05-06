using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.SewingThreadAndNeedleDetails.DTOs
{
    public class GetSewingThreadAndNeedleDetailInput
    {
        public Guid Id { get; set; }
    }

    [AutoMap(typeof(SewingThreadAndNeedleDetail))]

    public class SewingThreadAndNeedleDetailListDto : FullAuditedEntityDto<Guid>
    {
        // public string Style { get; set; }
        public Guid StyleId { get; set; }

        public string SeamType { get; set; }

        public string SPI { get; set; }

        public string TKTNo { get; set; }

        public string NeedleType { get; set; }

        public string NeedleSize { get; set; }

        public string Remark { get; set; }
    }
}
