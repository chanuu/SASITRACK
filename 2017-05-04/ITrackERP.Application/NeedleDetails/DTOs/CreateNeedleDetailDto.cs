using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.NeedleDetails.DTOs
{
    [AutoMap(typeof(NeedleDetail))]
    public class CreateNeedleDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }
        public string NeedleType { get; set; }
        public string Remark { get; set; }
    }
}
