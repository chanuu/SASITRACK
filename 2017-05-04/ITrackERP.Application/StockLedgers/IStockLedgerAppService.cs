using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.StockLedgers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.StockLedgers
{
    public interface IStockLedgerAppService : IApplicationService
    {
        ListResultOutput<StockLedgerDto> GetStockLedger();

        ListResultOutput<StockLedgerDto> GetItemBalance();
        Task Create(CreateStockLedgerDto input);

        Task Update(EditStockLedgerDto input);
        
        Task UpdateStockLedgerByDocNo(DocNoDto input);


        Task Delete(DeleteStockLedgerDto input);
    }
}
