using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Asset_Ledgers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Ledgers
{
    public interface IAssetLedgerAppService : IApplicationService
    {
        ListResultOutput<AssetLedgerListDto> GetAssetLedgers();

        AssetLedgerDetailOutputDto GetDetail(EntityResultOutput<Guid> input);

        string GetTransactionID();
        Task Create(CreateAssetLedgerDto input);

        Task Update(EditAssetLedgerDto input);

        Task UpdateAssetLedgerByDocNo(DocNoDto input);
        Task DeleteAssetLedger(DeleteAssetLedgerDto input);
    }
}
