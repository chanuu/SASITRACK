using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FootDetails.DTOs
{
    [AutoMap(typeof(FootDetail))]
    public class CreateFootDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }
        public string FootType { get; set; }
        public string Remark { get; set; }
    }
}
