using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.EventHeaders.DTOs;
using ITrackERP.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.EventHeaders
{
    public class EventHeaderAppService : ITrackERPAppServiceBase, IEventHeaderAppService
    {
        private readonly IRepository<EventHeader, Guid> _eventHeaderRepository;

        public EventHeaderAppService(IRepository<EventHeader, Guid> eventHeaderRepository)
        {
            _eventHeaderRepository = eventHeaderRepository;
        }

        public ListResultOutput<EventHeaderListDto> GetAll() 
        {
            var eventHeaders = _eventHeaderRepository.GetAll().ToList();

            return new ListResultOutput<EventHeaderListDto>(eventHeaders.MapTo<List<EventHeaderListDto>>());
        }

        public EventHeaderDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @eventHeader = _eventHeaderRepository
                .GetAll()
                .Include(x => x.Albums)
                .Include(x => x.Invitees)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@eventHeader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @eventHeader.MapTo<EventHeaderDto>();
        }

        public async Task Create(CreateEventHeaderDto input)
        {
            var @eventHeader = input.MapTo<EventHeader>();
            @eventHeader = EventHeader.Create(AbpSession.GetTenantId(), input.Name, input.Description, input.Type, input.Date.Value, input.Frequency, input.ExpectedDate.Value, input.Department, input.Venue);
            await _eventHeaderRepository.InsertAsync(@eventHeader);

        }

        public async Task Update(EditEventHeaderDto input)
        {
            var @eventHeader = input.MapTo<EventHeader>();
            @eventHeader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _eventHeaderRepository.UpdateAsync(@eventHeader);
        }
        public async Task Delete(DeleteEventHeaderDto input)
        {
            var @eventHeader = input.MapTo<EventHeader>();

            await _eventHeaderRepository.DeleteAsync(@eventHeader.Id);
        }

    }
}

