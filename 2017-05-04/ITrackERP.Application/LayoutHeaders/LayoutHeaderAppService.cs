using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.LayoutHeaders.DTOs;
using ITrackERP.TAW;
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

namespace ITrackERP.LayoutHeaders
{
    public class LayoutHeaderAppService: ITrackERPAppServiceBase, ILayoutHeaderAppService
    {
        private readonly IRepository<DividingPlanHeader, Guid> _dividingplanheaderRepository;

        private readonly IRepository<LayoutHeader, Guid> _layoutHeaderRepository;

        private readonly IRepository<LayoutItem, Guid> _layoutItemRepository;

        public LayoutHeaderAppService(IRepository<DividingPlanHeader, Guid> dividingplanheaderRepository, IRepository<LayoutHeader, Guid> layoutHeaderRepository, IRepository<LayoutItem, Guid> layoutItemRepository)
        {
            _dividingplanheaderRepository = dividingplanheaderRepository;
            _layoutHeaderRepository = layoutHeaderRepository;
            _layoutItemRepository = layoutItemRepository;
        }

        public ListResultOutput<LayoutHeaderListDto> GetLayoutHeader()
        {
            var layoutheader = _layoutHeaderRepository.GetAll();

            return new ListResultOutput<LayoutHeaderListDto>(layoutheader.MapTo<List<LayoutHeaderListDto>>());
        }

    
        public LayoutHeaderDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @layoutheader = _layoutHeaderRepository
                .GetAll()
                
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@layoutheader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @layoutheader.MapTo<LayoutHeaderDto>();

        }

        public LayoutHeaderDto GetDetailByDividingPlanHeaderId(DividingPlanHeaderIdInputDto input)
        {
            var @layoutheader = _layoutHeaderRepository
                .GetAll()
                .Where(e => e.DividingPlanHeaderId == input.DividingPlanHeaderId)
                .ToList().FirstOrDefault();
         
            return @layoutheader.MapTo<LayoutHeaderDto>();

        }

        public bool HeaderIdCheck(DividingPlanHeaderIdInputDto input)
        {
            var @layoutheader = _layoutHeaderRepository
                .GetAll()
                .Where(e => e.DividingPlanHeaderId == input.DividingPlanHeaderId)
                .ToList().FirstOrDefault();

            if (@layoutheader == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

       
        public async Task Create(CreateLayoutHeaderDto input)
        {
          
            var header = _dividingplanheaderRepository.Get(input.DividingPlanHeaderId);

            var @layoutheader = input.MapTo<LayoutHeader>();

            @layoutheader.TenantId = AbpSession.GetTenantId();

            @layoutheader = LayoutHeader.Create(input.LayoutJson,input.Remark);

            header.LayoutHeaders.Add(@layoutheader);

            await CurrentUnitOfWork.SaveChangesAsync();

        }

        public async Task Update(EditLayoutHeaderDto input)
        {
            var @layoutheader = input.MapTo<LayoutHeader>();
            @layoutheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _layoutHeaderRepository.UpdateAsync(@layoutheader);
        }

        public async Task Delete(DeleteLayoutHeaderDto input)
        {
            var @layoutheader = input.MapTo<LayoutHeader>();
            await _layoutHeaderRepository.DeleteAsync(@layoutheader.Id);
        }
      
    }
}