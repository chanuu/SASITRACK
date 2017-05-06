using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Asset_Disposal_Headers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Disposal_Headers
{
    public interface IAssetDisposalHeaderAppService: IApplicationService
    {
        ListResultOutput<AssetDisposalHeaderListDto> GetAssetDisposalHeader();

        AssetDisposalHeaderDto GetDetail(EntityRequestInput<Guid> input);

        AssetDisposalDetailDto GetAssetDisposalDetailsByID(EntityRequestInput<Guid> input);

        Task CreateHeader(CreateAssetDisposalHeaderDto input);

        Task UpdateHeader(EditAssetDisposalHeaderDto input);

        Task DeleteHeader(DeleteAssetDisposalHeaderDto input);

        Task UpdateDetail(EditAssetDisposalDetailDto input);

        Task CreateDetail(CreateAssetDisposalDetailDto input);

        Task DeleteDetail(DeleteAssetDisposalDetailDto input);

        
    }

}
