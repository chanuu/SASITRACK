using Abp.AutoMapper;
using ITRACK.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios.Dto
{
    [AutoMapFrom(typeof(CuttingRatio))]
    public  class CuttingRatioListDto
    {
        public virtual Guid StyleId { get; set; }
        public virtual string RatioNo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Length { get; set; }

        public virtual double MarkerLength { get; set; }

        public virtual double MarkerWidth { get; set; }

        public virtual double LayerLength { get; set; }

        public virtual string FabricType { get; set; }

        public virtual string Remark { get; set; }

        public virtual Guid Id { get; set; }

        public virtual ICollection<CuttingRatioItemDto> CuttingRatioItem { get; set; }

    }
}
