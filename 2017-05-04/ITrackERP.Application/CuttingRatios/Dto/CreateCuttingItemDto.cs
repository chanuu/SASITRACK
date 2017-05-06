using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios.Dto
{
    [AutoMap(typeof(CuttingItem))]
    public  class CreateCuttingItemDto : FullAuditedEntityDto<Guid>
    {

        public Guid CuttingMasterId { get; set; }

        public string CutNo { get; set; }

        public string PoNo { get; set; }

        public string LayerNo { get; set; }

        public string FabricType { get; set; }

        public DateTime Date { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public double Length { get; set; }

        public string LotNo { get; set; }

        public int NoOfItem { get; set; }

        public int NoOfPlys { get; set; }

        public string IsTagGenarated { get; set; }

        public string IsIssued { get; set; }

        public DateTime TagPrintedTime { get; set; }

        public virtual Guid CuttingRatioId { get; set; }
    }
}
