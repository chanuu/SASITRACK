using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.StockReceiveHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.StockReceiveHeaders
{
    public interface IStockReceiveHeaderAppService : IApplicationService
    {
        ListResultOutput<StockReceiveHeaderDto> GetStockReceiveHeader();

        StockReceiveHeaderListDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateStockReceiveHeaderDto input);

        Task Update(EditStockReceiveHeaderDto input);

        Task Delete(DeleteStockReceiveHeaderDto input);
    }
}
