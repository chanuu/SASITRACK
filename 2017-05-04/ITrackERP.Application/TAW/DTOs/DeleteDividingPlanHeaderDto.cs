﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW.DTOs
{
    [AutoMap(typeof(DividingPlanHeader))]
    public class DeleteDividingPlanHeaderDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
