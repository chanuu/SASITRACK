using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.PastEmployeements.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.PastEmployeements
{
    public interface IPastEmployeementAppService : IApplicationService
    {

        PastEmployeementDto GetPastEmployeementByID(EntityRequestInput<Guid> input);
        Task UpdatePastEmployeement(EditPastEmployeementDto input);

        Task CreatePastEmployeement(CreatePastEmployeementDto input);

        Task DeletePastEmployment(DeletePastEmploymentDto input);

    }
}

