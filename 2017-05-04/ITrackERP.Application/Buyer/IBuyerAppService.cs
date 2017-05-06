using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Buyer.Dto;
using ITrackERP.BuyerProfiles.Dto;
using ITrackERP.Styles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Buyer
{
   public interface IBuyerAppService: IApplicationService
    {
        ListResultOutput<BuyerProfileListDto> GetBuyers();

        BuyerProfileDetailsOutputDto GetDetail(EntityRequestInput<Guid> input);

        Task Create(CreateBuyerProfileInputDto input);

        Task DeleteBuyer(CreateBuyerProfileInputDto input);
    }
}
