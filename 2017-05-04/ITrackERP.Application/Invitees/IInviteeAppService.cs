using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Invitees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Invitees
{
    public interface IInviteeAppService : IApplicationService
    {
        InviteeDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateInviteeDto input);

        Task Update(EditInviteeDto input);

        Task Delete(DeleteInviteeDto input);
    }
}
