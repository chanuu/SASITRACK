using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingMasters.Dto
{
    [AutoMap(typeof(CuttingSummaryViewModel))]
  public  class CuttingSummaryDto
    {
        public DateTime Date { get; set; }
        public string StyleNo { get; set; }

        public int PlanQty { get; set; }

        public int ActualQty { get; set; }

        public int OrderQty { get; set; }

        public int Cumm { get; set; }

        public int Balance { get; set; }
    }
}
