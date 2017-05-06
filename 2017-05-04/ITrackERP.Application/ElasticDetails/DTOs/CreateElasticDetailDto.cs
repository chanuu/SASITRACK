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
    public class CreateElasticDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid StyleId { get; set; }

        public string FabricColour { get; set; }

        public string ElasticColour { get; set; }

        public string Cumption { get; set; }

        public double Width { get; set; }

        public string Remark { get; set; }
    }
}
