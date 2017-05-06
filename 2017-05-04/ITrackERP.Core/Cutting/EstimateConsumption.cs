using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;

namespace ITRACK.Cutting
{
   
    public class EstimateConsumptione : FullAuditedEntity<Guid>, IMustHaveTenant
    {
       
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string EstimateConsumptionNo { get; set; }

        public virtual string LayerNo { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int NoOfPlys { get; set; }

        public virtual double SinglePcsConsumption { get; set; }

        public virtual double ActualSinglePcsConsumption { get; set; }

        public virtual double TotalFabricPlan { get; set; }

        public virtual int TotalPcs { get; set; }

        public virtual double  ActualFabric { get; set; }

        public virtual double Deference { get; set; }


        public static EstimateConsumptione Create(int tenantId, string layerNo, DateTime date, int noOfPlys,
            double singlePcsConsumption, double actSinglePcsConsumption, double totalFabricPlan, int totalPcs,
            double actualFabric, double deference,Guid styleId)
        {

            var @estimateconsumption = new EstimateConsumptione()
            {
                Id = Guid.NewGuid(),
                LayerNo = layerNo,
                Date =date,
                NoOfPlys = noOfPlys,
                SinglePcsConsumption = singlePcsConsumption,
                ActualSinglePcsConsumption = actSinglePcsConsumption,
                TotalFabricPlan = totalFabricPlan,
                TotalPcs = totalPcs,
                ActualFabric = actualFabric,
                Deference = deference,
                TenantId = tenantId,
                StyleId = styleId

            };

            return @estimateconsumption;
        }
    }



}
