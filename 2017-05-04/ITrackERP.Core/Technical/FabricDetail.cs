using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Technical
{
    public class FabricDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }
        public virtual Guid StyleId { get; set; }



        public virtual string FabricType { get; set; }

        public virtual bool isFullyInspected { get; set; }

        public virtual bool isPartiallyInspected { get; set; }

        public virtual double ShrinkageToSteam { get; set; }

        public virtual double ShrinkageToWashing { get; set; }

        public virtual double ShrinkageToFusing { get; set; }

        public virtual double FabricRelaxation24Hours { get; set; }

        public virtual double LayingOnPins { get; set; }

        public virtual double LotOnToFollow { get; set; }

        public virtual double FaceToFace { get; set; }
        public virtual double BlockAndRelayOnPins { get; set; }

        public virtual double TwillDirection { get; set; }

        public virtual double NapUp { get; set; }
        public virtual double NapDown { get; set; }

        public virtual double Custom { get; set; }


        public static FabricDetail Create(string fabricType, double shrinkageToSteam, double shrinkageToWashing, double shrinkageToFusing, double fabricRelaxation24Hours,
            double layingOnPins, double lotOnToFollow, double faceToFace, double blockAndRelayOnPins, double twillDirection,
            double napUp, double napDown, double custom)
        {
            var @fabricdetail = new FabricDetail
            {
                Id = Guid.NewGuid(),
                FabricType = fabricType,
                ShrinkageToSteam = shrinkageToSteam,
                ShrinkageToWashing = shrinkageToWashing,
                ShrinkageToFusing = shrinkageToFusing,
                FabricRelaxation24Hours = fabricRelaxation24Hours,
                LayingOnPins = layingOnPins,
                LotOnToFollow = lotOnToFollow,
                FaceToFace = faceToFace,
                BlockAndRelayOnPins = blockAndRelayOnPins,
                TwillDirection = twillDirection,
                NapUp = napUp,
                NapDown = napDown,
                Custom = custom,
                isFullyInspected = false,
                isPartiallyInspected = false,
            };


            return @fabricdetail;



        }

    }
}
