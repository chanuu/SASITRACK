﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FabricDetails.DTOs
{
    [AutoMap(typeof(FabricDetail))]
    public class DeleteFabricDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
