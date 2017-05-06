using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.LayoutItems.DTOs;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Linq.Extensions;
using System.Data.Entity;

namespace ITrackERP.LayoutItems
{
    public class LayoutItemAppService: ITrackERPAppServiceBase, ILayoutItemAppService
    {
        private readonly IRepository<LayoutItem, Guid> _layoutItemRepository;

        private readonly IRepository<LayoutHeader, Guid> _layoutHeaderRepository;



        public LayoutItemAppService(IRepository<LayoutItem, Guid> layoutItemRepository, IRepository<LayoutHeader, Guid> layoutHeaderRepository)
        {
            _layoutHeaderRepository = layoutHeaderRepository;
            _layoutItemRepository = layoutItemRepository;
        }

        public ListResultOutput<LayoutItemDto> GetLayoutItem()
        {
            var layoutItem = _layoutItemRepository.GetAll();

            return new ListResultOutput<LayoutItemDto>(layoutItem.MapTo<List<LayoutItemDto>>());
        }

        public LayoutItemDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @layoutItem = _layoutItemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @layoutItem.MapTo<LayoutItemDto>();
        }

             
        public async Task Create(CreateLayoutItemDto input)
        {

            var _header = _layoutHeaderRepository.Get(input.LayoutHeaderId);

            var @layoutItem = input.MapTo<LayoutItem>();

            @layoutItem.TenantId = AbpSession.GetTenantId();

            @layoutItem = LayoutItem.Create(AbpSession.GetTenantId(),input.Key, input.Size, input.Source, input.Position, input.Group);

            _header.LayoutItems.Add(@layoutItem);
          
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Update(EditLayoutItemDto input)
        {
            var @layoutItem = input.MapTo<LayoutItem>();
            @layoutItem.TenantId = AbpSession.GetTenantId();

            await _layoutItemRepository.UpdateAsync(@layoutItem);
        }

        public async Task Delete(DeleteLayoutItemDto input)
        {
            var @layoutItem = input.MapTo<LayoutItem>();

            await _layoutItemRepository.DeleteAsync(@layoutItem.Id);
        }
    }
}

