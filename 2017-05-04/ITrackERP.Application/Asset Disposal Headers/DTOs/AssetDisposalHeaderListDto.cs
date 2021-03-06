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
    [AutoMapFrom(typeof(AssetDisposalHeader))]
    public class AssetDisposalHeaderListDto : FullAuditedEntityDto<Guid>
    {
        public string DisposalNoteNo { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string DisposalBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
