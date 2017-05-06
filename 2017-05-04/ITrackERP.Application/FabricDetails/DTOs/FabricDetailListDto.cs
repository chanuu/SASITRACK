using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FabricDetails.DTOs
{
    public class GetFabricDetailInput
    {
        public Guid Id { get; set; }
    }

    [AutoMap(typeof(FabricDetail))]

    public class FabricDetailListDto : FullAuditedEntityDto<Guid>
    {
        // public string Style { get; set; }
        public Guid StyleId { get; set; }
        public string FabricType { get; set; }

        // public bool isFullyInspected { get; set; }

        //  public bool isPartiallyInspected { get; set; }

        public double ShrinkageToSteam { get; set; }

        public double ShrinkageToWashing { get; set; }

        public double ShrinkageToFusing { get; set; }

        public double FabricRelaxation24Hours { get; set; }

        public double LayingOnPins { get; set; }

        public double LotOnToFollow { get; set; }

        public double FaceToFace { get; set; }
        public double BlockAndRelayOnPins { get; set; }

        public double TwillDirection { get; set; }

        public double NapUp { get; set; }
        public double NapDown { get; set; }

        public double Custom { get; set; }
    }
}
