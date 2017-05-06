using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.AssetVerificationHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.AssetVerificationHeaders
{
    public interface IAssetVerificationHeaderAppService : IApplicationService
    {
        ListResultOutput<AssetVerificationHeaderListDto> GetAll();
        AssetVerificationHeaderDto GetDetail(EntityResultOutput<Guid> input);
        Task Create(CreateAssetVerificationHeaderDto input);
        Task Update(EditAssetVerificationHeaderDto input);
    }
}
