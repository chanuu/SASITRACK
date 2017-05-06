using Abp.AutoMapper;
using ITrackERP.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Productions.DTOs
{
    [AutoMap(typeof(DailyProductionSummary))]
    public  class ProductionSummaryDto
    {

        public virtual DateTime Date { get; set; }


        public virtual string LineNo { get; set; }


        public virtual string StyleNo { get; set; }

        public string PoNo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual string Length { get; set; }

        public virtual int CutQty { get; set; }

        public virtual int LineIn { get; set; }

        public virtual int LineInCumm { get; set; }

        public int LineInTotal { get; set; }

        public virtual int LineOut { get; set; }

        public virtual int LineOutCumm { get; set; }

        public int LineOutTotal { get; set; }
    }

    [AutoMap(typeof(DailyProductionSummary))]
    public class ProductionFilter
    {
        public virtual DateTime Date { get; set; }
    }
}
