using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITRACK.Company;
using ITrackERP.SewingThreadAndNeedleDetails.DTOs;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Runtime.Session;

namespace ITrackERP.SewingThreadAndNeedleDetails
{
    public class SewingThreadAndNeedleDetailAppService: ITrackERPAppServiceBase, ISewingThreadAndNeedleDetailAppService
    {
        private readonly IRepository<SewingThreadAndNeedleDetail, Guid> _sewingThreadAndNeedleDetailRepository;

        private readonly IRepository<Style ,Guid> _styleRepository;


        public SewingThreadAndNeedleDetailAppService(IRepository<Style, Guid> styleRepository, IRepository<SewingThreadAndNeedleDetail, Guid> sewingThreadAndNeedleDetailRepository)
        {
             _styleRepository = styleRepository;

             _sewingThreadAndNeedleDetailRepository = sewingThreadAndNeedleDetailRepository;
        }

        public ListResultDto<SewingThreadAndNeedleDetailListDto> GetSewingThreadAndNeedleDetails(GetSewingThreadAndNeedleDetailInput input)
        {
            var @style = _sewingThreadAndNeedleDetailRepository.GetAll()
                .Where(x => x.StyleId == input.Id)
                .Include(x => x.Style);

            return new ListResultDto<SewingThreadAndNeedleDetailListDto>(style.ProjectTo<SewingThreadAndNeedleDetailListDto>().ToList());

        }

        public ListResultDto<SewingThreadAndNeedleDetailListDto> GetSewingThreadAndNeedleDetailsByID(EntityRequestInput<Guid> input)
        {
            var @sewingThreadAndNeedleDetail = _sewingThreadAndNeedleDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id);


            return new ListResultDto<SewingThreadAndNeedleDetailListDto>(@sewingThreadAndNeedleDetail.ProjectTo<SewingThreadAndNeedleDetailListDto>().ToList());

        }
        public async Task UpdateDetail(EditSewingThreadAndNeedleDetailDto input)
        {
            var @sewingThreadAndNeedleDetail = input.MapTo<SewingThreadAndNeedleDetail>();
            //  @sewingThreadAndNeedleDetail.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _sewingThreadAndNeedleDetailRepository.UpdateAsync(@sewingThreadAndNeedleDetail);
        }

        public async Task CreateDetail(CreateSewingThreadAndNeedleDetailDto input)
        {
            var _header = _styleRepository.Get(input.StyleId);

            var @sewingThreadAndNeedleDetail = input.MapTo<SewingThreadAndNeedleDetail>();

            @sewingThreadAndNeedleDetail.TenantId = AbpSession.GetTenantId();

            @sewingThreadAndNeedleDetail = SewingThreadAndNeedleDetail.Create(input.SeamType, input.SPI, input.TKTNo, input.NeedleType, input.NeedleSize, input.Remark);

            _header.SewingThreadAndNeedleDetails.Add(@sewingThreadAndNeedleDetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteSewingThreadAndNeedleDetailDto input)
        {
            var @sewingThreadAndNeedleDetail = input.MapTo<SewingThreadAndNeedleDetail>();

            await _sewingThreadAndNeedleDetailRepository.DeleteAsync(@sewingThreadAndNeedleDetail.Id);
        }
    }
}
