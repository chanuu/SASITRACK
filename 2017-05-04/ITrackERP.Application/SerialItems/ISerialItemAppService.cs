using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.SerialItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.SerialItems
{
    public interface ISerialItemAppService : IApplicationService
    {  
        ListResultOutput<SerialItemDto> GetSerialItem();
        
        ListResultOutput<SerialItemDto> GetSerialItemByItemCode(GetSerialItemByItemCodeInputDto input);

        SerialItemDto GetSerialItemByID(EntityRequestInput<Guid> input);
        SerialItemDto GetDetailBySerialNo(SerialNoInputDto input);
   
        Task Create(CreateSerialItemDto input);

        Task Update(EditSerialItemDto input);

        Task UpdateSerialItemBySerialNo(SerialNoInputDto input);

        Task UpdateSerialItemBySerialNo1(SerialNoInputDto input);

        Task Delete(DeleteSerialItemDto input);
    }
}
