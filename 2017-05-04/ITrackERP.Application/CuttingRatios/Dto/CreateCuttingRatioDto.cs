﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITRACK.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios.Dto
{
    [AutoMap(typeof(CuttingRatio))]
    public  class CreateCuttingRatioInputDto
    {
        public virtual Guid StyleId { get; set; }
        public virtual string RatioNo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Length { get; set; }

        public virtual double MarkerLength { get; set; }

        public virtual double MarkerWidth { get; set; }

        public virtual double LayerLength { get; set; }

        public virtual string FabricType { get; set; }

        public virtual string Remark { get; set; }


    }
}
