using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.ItemMaster.Dto;

namespace ITrackERP.ItemMaster
{
    public interface IItemMasterAppService : IApplicationService
    {
        ListResultOutput<ItemMasterListDto> GetItemMaster();

        ItemMasterDetailOutputDto GetDetail(EntityRequestInput<Guid> input);

        ItemMasterDetailOutputDto GetDetailByItemCode(ItemCodeInputDto input);
        Task Create(CreateItemMasterInputDto input);

        Task Update(EditItemMasterInputDto input);

        Task Delete(DeleteItemMasterInputDto input);

    }
}
