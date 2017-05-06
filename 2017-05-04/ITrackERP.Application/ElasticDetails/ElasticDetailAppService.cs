using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITRACK.Company;
using ITrackERP.ElasticDetails.DTOs;
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

namespace ITrackERP.ElasticDetails
{
    public class ElasticDetailAppService: ITrackERPAppServiceBase, IElasticDetailAppService
    {
        private readonly IRepository<ElasticDetail, Guid> _elasticDetailRepository;

        private readonly IRepository<Style ,Guid> _styleRepository;


        public ElasticDetailAppService(IRepository<Style, Guid> styleRepository, IRepository<ElasticDetail, Guid> elasticDetailRepository)
        {
             _styleRepository = styleRepository;

             _elasticDetailRepository = elasticDetailRepository;
        }

        public ListResultDto<ElasticDetailListDto> GetElasticDetails(GetElasticDetailInput input)
        {
            var @style = _elasticDetailRepository.GetAll()
                .Where(x => x.StyleId == input.Id)
                .Include(x => x.Style);

            return new ListResultDto<ElasticDetailListDto>(style.ProjectTo<ElasticDetailListDto>().ToList());

        }

        public ListResultDto<ElasticDetailListDto> GetElasticDetailsByID(EntityRequestInput<Guid> input)
        {
            var @elasticdetails = _elasticDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id);


            return new ListResultDto<ElasticDetailListDto>(@elasticdetails.ProjectTo<ElasticDetailListDto>().ToList());

        }
        public async Task UpdateDetail(EditElasticDetailDto input)
        {
            var @elasticdetail = input.MapTo<ElasticDetail>();
            //  @elasticdetail.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _elasticDetailRepository.UpdateAsync(@elasticdetail);
        }

        public async Task CreateDetail(CreateElasticDetailDto input)
        {
            var _style = _styleRepository.Get(input.StyleId);

            var @elasticdetail = input.MapTo<ElasticDetail>();

            @elasticdetail.TenantId = AbpSession.GetTenantId();

            @elasticdetail = ElasticDetail.Create(input.FabricColour, input.ElasticColour, input.Cumption, input.Width, input.Remark);

            _style.ElasticDetails.Add(@elasticdetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteElasticDetailDto input)
        {
            var @elasticdetail = input.MapTo<ElasticDetail>();

            await _elasticDetailRepository.DeleteAsync(@elasticdetail.Id);
        }
    }
}

