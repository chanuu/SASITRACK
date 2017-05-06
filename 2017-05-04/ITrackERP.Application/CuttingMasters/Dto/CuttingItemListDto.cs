using Abp.AutoMapper;
using ITrackERP.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingMasters.Dto
{


    public class GetCuttingItemInput
    {
        public string Filter { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }



    [AutoMap(typeof(CuttingItem))]
  public  class CuttingItemListDto
    {

        public string CutNo { get; set; }

        public string StyleNo { get; set; }

        public string StyleId { get; set; }

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

    }
}
