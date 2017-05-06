using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.ElasticDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ElasticDetails
{
    public interface IElasticDetailAppService : IApplicationService
    {
        ListResultDto<ElasticDetailListDto> GetElasticDetails(GetElasticDetailInput input);

        ListResultDto<ElasticDetailListDto> GetElasticDetailsByID(EntityRequestInput<Guid> input);

        Task CreateDetail(CreateElasticDetailDto input);

        Task UpdateDetail(EditElasticDetailDto input);

        Task DeleteDetail(DeleteElasticDetailDto input);
    }
}
