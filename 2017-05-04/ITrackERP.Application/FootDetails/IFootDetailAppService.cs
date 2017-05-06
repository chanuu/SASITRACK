using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.FootDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FootDetails
{
    public interface IFootDetailAppService : IApplicationService
    {
        FootDetailDto GetFootDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateFootDetail(EditFootDetailDto input);

        Task CreateFootDetail(CreateFootDetailDto input);

        Task DeleteFootDetail(DeleteFootDetailDto input);


    }

}