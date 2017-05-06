using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITRACK.Company;
using ITrackERP.Technical;
using ITrackERP.ZipperDetails.DTOs;
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

namespace ITrackERP.ZipperDetails
{
    public class ZipperDetailAppService : ITrackERPAppServiceBase, IZipperDetailAppService
    {
        private readonly IRepository<ZipperDetail, Guid> _zipperDetailRepository;

        private readonly IRepository<Style ,Guid> _styleRepository;


        public ZipperDetailAppService(IRepository<Style, Guid> styleRepository, IRepository<ZipperDetail, Guid> zipperDetailRepository)
        {
             _styleRepository = styleRepository;

             _zipperDetailRepository = zipperDetailRepository;
        }

        public ListResultDto<ZipperDetailListDto> GetZipperDetails(GetZipperDetailInput input)
        {
            var @style = _zipperDetailRepository.GetAll()
                .Where(x => x.StyleId == input.Id)
                .Include(x => x.Style);

            return new ListResultDto<ZipperDetailListDto>(style.ProjectTo<ZipperDetailListDto>().ToList());

        }

        public ListResultDto<ZipperDetailListDto> GetZipperDetailsByID(EntityRequestInput<Guid> input)
        {
            var @zipperdetails = _zipperDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id);


            return new ListResultDto<ZipperDetailListDto>(@zipperdetails.ProjectTo<ZipperDetailListDto>().ToList());

        }
        public async Task UpdateDetail(EditZipperDetailDto input)
        {
            var @zipperdetail = input.MapTo<ZipperDetail>();
            //  @zipperdetail.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _zipperDetailRepository.UpdateAsync(@zipperdetail);
        }

        public async Task CreateDetail(CreateZipperDetailDto input)
        {
            var _style = _styleRepository.Get(input.StyleId);

            var @zipperdetail = input.MapTo<ZipperDetail>();

            @zipperdetail.TenantId = AbpSession.GetTenantId();

            @zipperdetail = ZipperDetail.Create(input.FabricColour, input.ZipperColour, input.ZipperLength, input.Size, input.Remark);

            _style.ZipperDetails.Add(@zipperdetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteZipperDetailDto input)
        {
            var @zipperdetail = input.MapTo<ZipperDetail>();

            await _zipperDetailRepository.DeleteAsync(@zipperdetail.Id);
        }
    }
}

