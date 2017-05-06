using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.AssetVerificationDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.AssetVerificationDetails
{
    public interface IAssetVerificationDetailAppService : IApplicationService
    {
        Task Create(CreateAssetVerificationDetailDto input);

    }
}
