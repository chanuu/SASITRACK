using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.ZipperDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ZipperDetails
{
    public interface IZipperDetailAppService : IApplicationService
    {
        ListResultDto<ZipperDetailListDto> GetZipperDetails(GetZipperDetailInput input);

        ListResultDto<ZipperDetailListDto> GetZipperDetailsByID(EntityRequestInput<Guid> input);

        Task CreateDetail(CreateZipperDetailDto input);

        Task UpdateDetail(EditZipperDetailDto input);

        Task DeleteDetail(DeleteZipperDetailDto input);
    }
}
