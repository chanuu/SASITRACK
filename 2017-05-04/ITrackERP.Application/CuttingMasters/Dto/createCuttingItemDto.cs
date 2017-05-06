using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingMasters.Dto
{
    [AutoMap(typeof(CuttingItem))]
    public  class createCuttingItemDto : FullAuditedEntityDto<Guid>
    {
        public virtual int TenantId { get; set; }

      
        public virtual Guid CuttingMasterId { get; set; }

        public virtual string CutNo { get; set; }

        public virtual string PoNo { get; set; }

        public virtual string LayerNo { get; set; }

        public virtual string FabricType { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual double Length { get; set; }

        public virtual string LotNo { get; set; }

        public virtual int NoOfItem { get; set; }

        public virtual int NoOfPlys { get; set; }
    }
}
