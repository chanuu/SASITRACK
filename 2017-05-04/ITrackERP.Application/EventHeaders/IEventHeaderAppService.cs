using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.EventHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.EventHeaders
{
    public interface IEventHeaderAppService : IApplicationService
    {
        ListResultOutput<EventHeaderListDto> GetAll();

        EventHeaderDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateEventHeaderDto input);

        Task Update(EditEventHeaderDto input);

        Task Delete(DeleteEventHeaderDto input);
    }
}

