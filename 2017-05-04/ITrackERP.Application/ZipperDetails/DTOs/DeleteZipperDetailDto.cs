using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ZipperDetails.DTOs
{
    [AutoMap(typeof(ZipperDetail))]
    public class DeleteZipperDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}

