using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ElasticDetails.DTOs
{
    [AutoMap(typeof(ElasticDetail))]
    public class DeleteElasticDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
