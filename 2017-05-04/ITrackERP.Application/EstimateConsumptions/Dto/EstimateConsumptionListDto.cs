using Abp.AutoMapper;
using ITRACK.Cutting;
using ITrackERP.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.EstimateConsumption.Dto
{

    public class GetEstimateConsumtionInput
    {
        public string Filter { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }



    [AutoMapFrom(typeof(EstimateConsumptione))]
    public class EstimateConsumptionListDto 
    {
        public virtual string LayerNo { get; set; }

        public virtual string StyleNo { get; set; }


        public virtual DateTime Date { get; set; }

        public virtual int NoOfPlys { get; set; }

        public virtual double SinglePcsConsumption { get; set; }

        public virtual double ActualSinglePcsConsumption { get; set; }

        public virtual double TotalFabricPlan { get; set; }

        public virtual int TotalPcs { get; set; }

        public virtual double ActualFabric { get; set; }

        public virtual double Deference { get; set; }

    }
}
