using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.ReceiveNoteItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ReceiveNoteItems
{
    public interface IReceiveNoteItemAppService : IApplicationService
    {
        ReceiveNoteItemDto GetReceiveNoteItemsByID(EntityRequestInput<Guid> input);

        ReceiveNoteItemListDto GetDetail(EntityRequestInput<Guid> input);

        Task Create(CreateReceiveNoteItemDto input);

        Task Update(EditReceiveNoteItemDto input);

        Task Delete(DeleteReceiveNoteItemDto input);
    }
}
