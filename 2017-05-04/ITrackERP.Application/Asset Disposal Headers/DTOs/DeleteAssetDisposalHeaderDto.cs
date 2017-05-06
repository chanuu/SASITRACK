﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Disposal_Headers.DTOs
{
    [AutoMap(typeof(AssetDisposalHeader))]
    public class DeleteAssetDisposalHeaderDto: FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
