using Abp.AutoMapper;
using ITRACK.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios.Dto
{
    [AutoMapFrom(typeof(CuttingRatioItem))]
    public  class CuttingRatioItemDto
    {
        public virtual Guid CuttingRatioId { get; set; }

        public virtual string Size { get; set; }

        public virtual int Lot { get; set; }
    }
}
