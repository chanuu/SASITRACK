﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Productions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Productions
{
    public interface IProductionAppService : IApplicationService
    {
        ListResultDto<ProductionSummaryDto> GetProductionSummary(ProductionFilter input);
    }
}
