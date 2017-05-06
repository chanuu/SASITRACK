using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Company;
using ITRACK.Cutting;

namespace ITrackERP.EstimateConsumption.Dto
{
    [AutoMapFrom(typeof(EstimateConsumptione))]
    public class EstimateConsumptionDto : FullAuditedEntityDto<Guid>
    {
        public virtual string LayerNo { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int NoOfPlys { get; set; }

        public virtual double SinglePcsConsumption { get; set; }

        public virtual double ActualSinglePcsConsumption { get; set; }

        public virtual string TotalFabricPlan { get; set; }

        public virtual int TotalPcs { get; set; }

        public virtual double ActualFabric { get; set; }

        public virtual double Deference { get; set; }

    }
}
