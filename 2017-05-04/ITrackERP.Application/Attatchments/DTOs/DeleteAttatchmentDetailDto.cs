using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Attatchments.DTOs
{

[AutoMap(typeof(AttatchmentDetail))]

    public class DeleteAttatchmentDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}

