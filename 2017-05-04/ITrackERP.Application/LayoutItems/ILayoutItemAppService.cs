using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.LayoutItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.LayoutItems
{
    public interface ILayoutItemAppService : IApplicationService
    {
        ListResultOutput<LayoutItemDto> GetLayoutItem();
        LayoutItemDto GetDetail(EntityRequestInput<Guid> input);
     
        Task Create(CreateLayoutItemDto input);

        Task Update(EditLayoutItemDto input);

        Task Delete(DeleteLayoutItemDto input);
    }
}