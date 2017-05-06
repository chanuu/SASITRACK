using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Technical;
using ITrackERP.FabricDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using ITRACK.Company;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Runtime.Session;


namespace ITrackERP.FabricDetails
{
    public class FabricDetailAppService : ITrackERPAppServiceBase, IFabricDetailAppService
    {
        private readonly IRepository<FabricDetail, Guid> _fabricDetailRepository;

        private readonly IRepository<Style ,Guid> _styleRepository;


        public FabricDetailAppService(IRepository<Style, Guid> styleRepository,IRepository<FabricDetail, Guid> fabricDetailRepository)
        {
             _styleRepository = styleRepository;

            _fabricDetailRepository = fabricDetailRepository;
        }

         public ListResultDto<FabricDetailListDto> GetFabricDetails(GetFabricDetailInput input)
        {
            var @style = _fabricDetailRepository.GetAll()
                .Where(x => x.StyleId == input.Id)
                .Include(x => x.Style);

            return new ListResultDto<FabricDetailListDto>(style.ProjectTo<FabricDetailListDto>().ToList());

        }

        public ListResultDto<FabricDetailListDto> GetFabricDetailsByID(EntityRequestInput<Guid> input)
        {
            var @fabrictype = _fabricDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id);


            return new ListResultDto<FabricDetailListDto>(@fabrictype.ProjectTo<FabricDetailListDto>().ToList());

        }
        public async Task UpdateDetail(EditFabricDetailDto input)
        {
            var @fabricdetail = input.MapTo<FabricDetail>();
            //  @fabricdetail.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _fabricDetailRepository.UpdateAsync(@fabricdetail);
        }

        public async Task CreateDetail(CreateFabricDetailDto input)
        {
            var _header = _styleRepository.Get(input.StyleId);

            var @fabricdetail = input.MapTo<FabricDetail>();

            @fabricdetail.TenantId = AbpSession.GetTenantId();

            @fabricdetail = FabricDetail.Create(input.FabricType, input.ShrinkageToSteam, input.ShrinkageToWashing, input.ShrinkageToFusing, input.FabricRelaxation24Hours, input.LayingOnPins, input.LotOnToFollow, input.FaceToFace, input.BlockAndRelayOnPins, input.TwillDirection, input.NapUp, input.NapDown, input.Custom);

            _header.FabricDetails.Add(@fabricdetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteFabricDetailDto input)
        {
            var @fabricdetail = input.MapTo<FabricDetail>();

            await _fabricDetailRepository.DeleteAsync(@fabricdetail.Id);
        }
    }
}
