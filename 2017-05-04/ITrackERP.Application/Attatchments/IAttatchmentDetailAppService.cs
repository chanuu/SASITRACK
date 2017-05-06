using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Attatchments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Attatchments
{
    public interface IAttatchmentDetailAppService : IApplicationService
    {
        AttatchmentDetailDto GetAttatchmentDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateAttatchmentDetail(EditAttatchmentDetailDto input);

        Task CreateAttatchmentDetail(CreateAttatchmentDetailDto input);

        Task DeleteAttatchmentDetail(DeleteAttatchmentDetailDto input);


    }

}
