using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Maintenance;
using ITrackERP.StockLedgers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.StockLedgers
{
    public class StockLedgerAppService : ITrackERPAppServiceBase, IStockLedgerAppService
    {
        private readonly IRepository<StockLedger, Guid> _stockLedgerRepository;

        public StockLedgerAppService(IRepository<StockLedger, Guid> stockLedgerRepository)
        {
            _stockLedgerRepository = stockLedgerRepository;
        }

        public ListResultOutput<StockLedgerDto> GetStockLedger()
        {
            var stockLedger = _stockLedgerRepository.GetAll();

            return new ListResultOutput<StockLedgerDto>(stockLedger.MapTo<List<StockLedgerDto>>());
        }

        public ListResultOutput<StockLedgerDto> GetItemBalance()
        {
            var @stock = _stockLedgerRepository.GetAll().GroupBy(g => g.ItemCode).OrderBy(g => g.Key).Select(g => g.OrderByDescending(x => x.CreationTime).FirstOrDefault()).ToList();

            
            return new ListResultOutput<StockLedgerDto>(@stock.MapTo<List<StockLedgerDto>>());
        }
      
        public async Task Update(EditStockLedgerDto input)
        {
            var @stockLedger = input.MapTo<StockLedger>();
            @stockLedger.TenantId = AbpSession.GetTenantId();

            await _stockLedgerRepository.UpdateAsync(@stockLedger);
        }


        public async Task UpdateStockLedgerByDocNo(DocNoDto input)
        {
            var @stockledgers = _stockLedgerRepository.GetAll().ToList().Where(e => e.DocNo == input.DocNo);

            foreach (var item in @stockledgers)
            {
                item.Status = "Approved";
                item.TenantId = AbpSession.GetTenantId();
                await _stockLedgerRepository.UpdateAsync(item);
            }
        }

        public async Task Create(CreateStockLedgerDto input)
        {
            var @stockLedger = input.MapTo<StockLedger>();

            var @stock = _stockLedgerRepository.GetAll().WhereIf(true, x => x.ItemCode == input.ItemCode).OrderByDescending(x => x.CreationTime).FirstOrDefault();
           
            int balancestock = 0;
            int balance = 0;
           
            if (@stock == null)
            {
                balance = 0;
            }
            else
            {
                balance = @stock.BalanceStock;
            }

            if (input.TransactionType == "Job" || input.TransactionType == "Stock Cancel")
            {
     
                balancestock = balance - input.UsedStock;
            }

            else if (input.TransactionType == "Stock Receive" || input.TransactionType == "Job Cancel")
            {           
                balancestock = balance + input.UsedStock;
            }


            @stockLedger = StockLedger.Create(AbpSession.GetTenantId(), input.ItemCode, input.Date.Value, input.TransactionType, input.DocNo, input.UsedStock, balancestock, input.Status);

            await _stockLedgerRepository.InsertAsync(@stockLedger);

        }

        public async Task Delete(DeleteStockLedgerDto input)
        {
            var @stockLedger = input.MapTo<StockLedger>();

            await _stockLedgerRepository.DeleteAsync(@stockLedger.Id);
        }
    }
}
