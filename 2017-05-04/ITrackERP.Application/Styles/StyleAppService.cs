using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITrackERP.Styles.Dto;
using Abp.Domain.Repositories;
using ITRACK.Company;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Runtime.Session;

namespace ITrackERP.Styles
{
    public class StyleAppService : ITrackERPAppServiceBase, IStyleAppService
    {

        private readonly IRepository<Style ,Guid> _styleRepository;

       


        public StyleAppService(IRepository<Style, Guid> styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public StyleDetailOutputDto GetDetailByStyleNo(StyleNoInputDto input)
        {
            var @style = _styleRepository
                .GetAll()

                .Where(e => e.StyleNo == input.StyleNo)

                .ToList().FirstOrDefault();

            return @style.MapTo<StyleDetailOutputDto>();

        }

        public ListResultOutput<StyleListDto> GetStyles()
        {
            var styles = _styleRepository.GetAll();


            return new ListResultOutput<StyleListDto>(styles.MapTo<List<StyleListDto>>());
        }

        public StyleDetailOutput GetDetail(EntityRequestInput<Guid> input)
        {
            var @style =  _styleRepository
                .GetAll()
                
                .Where(e => e.Id == input.Id)
               
                .ToList().FirstOrDefault();

            if (@style == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return  @style.MapTo<StyleDetailOutput>();

        }

        public async Task Create(CreateStyleInputDto input)
        {
            var @style = input.MapTo<Style>();
            @style = Style.Create(AbpSession.GetTenantId(), input.StyleNo, input.ArticleNo, input.Season, input.Remark,input.OrderType,input.Department,input.BocNo,input.ItemType,input.BuyerName);
            int i = 0;
            await _styleRepository.InsertAsync(@style);
           
        }

        public async Task Update(EditStyleInputDto input)
        {
            var @style = input.MapTo<Style>();
            @style.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _styleRepository.UpdateAsync(@style);
        }

        public async Task DeleteStyle(DeleteStyleInputDto input)
        {
            var @style = input.MapTo<Style>();

            await _styleRepository.DeleteAsync(@style.Id);
        }
    }
}
