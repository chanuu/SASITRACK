using ITrackERP.Buyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITrackERP.Buyer.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using ITrackERP.BuyerProfiles.Dto;

namespace ITrackERP
{
    public class BuyerAppService : ITrackERPAppServiceBase, IBuyerAppService
    {
        private readonly IRepository<BuyerProfile, Guid> _buyerRepository;


        public BuyerAppService(IRepository<BuyerProfile, Guid> buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public async Task Create(CreateBuyerProfileInputDto input)
        {
            var @buyer = input.MapTo<BuyerProfile>();
            @buyer = BuyerProfile.Create(AbpSession.GetTenantId(), input.BuyerName, input.TeleNo, input.Address, input.Email, input.Remark);
          
            await _buyerRepository.InsertAsync(@buyer);
            
        }

        public async Task DeleteBuyer(CreateBuyerProfileInputDto input)
        {
            var @buyer = input.MapTo<BuyerProfile>();
         
            await _buyerRepository.DeleteAsync(@buyer.Id);
        }

        public ListResultOutput<BuyerProfileListDto> GetBuyers()
        {
            var buyers = _buyerRepository.GetAll().ToList();

            return new ListResultOutput<BuyerProfileListDto>(buyers.MapTo<List<BuyerProfileListDto>>());
        }

        public BuyerProfileDetailsOutputDto GetDetail(EntityRequestInput<Guid> input)
        {
            throw new NotImplementedException();
        }
    }
}
