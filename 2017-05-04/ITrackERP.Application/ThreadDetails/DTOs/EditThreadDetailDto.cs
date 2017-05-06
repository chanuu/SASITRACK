using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ThreadDetails.DTOs
{
    [AutoMap(typeof(ThreadDetail))]
    public class EditThreadDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }
        public string ThreadType { get; set; }
        public string Remark { get; set; }
    }
}

