using Abp.AutoMapper;
using ITRACK.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios.Dto
{
  
        [AutoMap(typeof(CuttingRatioItem))]
        public class CreateCuttingRatioItemDto
        {
        public virtual Guid CuttingRatioId { get; set; }

        public virtual string Size { get; set; }

        public virtual int Lot { get; set; }

        public virtual int TenantId { get; set; }
    }

    [AutoMap(typeof(CuttingRatioItem))]
    public class EditCuttingRatioItemDto
    {
        public virtual Guid CuttingRatioId { get; set; }

        public virtual string Size { get; set; }

        public virtual int Lot { get; set; }

        public virtual int TenantId { get; set; }
    }


}

