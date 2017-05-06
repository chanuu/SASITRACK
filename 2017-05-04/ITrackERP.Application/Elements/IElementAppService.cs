using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Elements.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Elements
{
    public interface IElementAppService : IApplicationService
    {
        ListResultOutput<ElementDto> GetElements();

        ElementDto GetDetail(EntityResultOutput<Guid> input);

        ListResultOutput<ElementDto> GetDetailByCategory(CategoryInputDto input);
        Task Create(CreateElementDto input);

        Task Update(EditElementDto input);

        Task Delete(DeleteElementDto input);
    }
}

