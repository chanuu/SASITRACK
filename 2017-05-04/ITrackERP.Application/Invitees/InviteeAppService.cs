using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.HR;
using ITrackERP.Invitees.DTOs;
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

namespace ITrackERP.Invitees
{
    public class InviteeAppService: ITrackERPAppServiceBase, IInviteeAppService
    {
        private readonly IRepository<Invitee, Guid> _inviteeRepository;
        private readonly IRepository<EventHeader, Guid> _eventHeaderRepository;

        public InviteeAppService(IRepository<Invitee, Guid> inviteeRepository, IRepository<EventHeader, Guid> eventHeaderRepository)
        {
            _inviteeRepository = inviteeRepository;
            _eventHeaderRepository = eventHeaderRepository;
        }

        public ListResultOutput<InviteeListDto> GetAll() 
        {
            var albums = _inviteeRepository.GetAll().ToList();

            return new ListResultOutput<InviteeListDto>(albums.MapTo<List<InviteeListDto>>());
        }

        public InviteeDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @invitee = _inviteeRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@invitee == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @invitee.MapTo<InviteeDto>();
        }

        public async Task Create(CreateInviteeDto input)
        {
            var @eventHeader = _eventHeaderRepository.Get(input.EventHeaderId);

            var @invitee = input.MapTo<Invitee>();
            @invitee = Invitee.Create(AbpSession.GetTenantId(), input.Name, input.Status);

            @eventHeader.Invitees.Add(@invitee);

            await CurrentUnitOfWork.SaveChangesAsync();


        }

        public async Task Update(EditInviteeDto input)
        {
            var @invitee = input.MapTo<Invitee>();
            @invitee.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _inviteeRepository.UpdateAsync(@invitee);
        }
        public async Task Delete(DeleteInviteeDto input)
        {
            var @invitee = input.MapTo<Invitee>();

            await _inviteeRepository.DeleteAsync(@invitee.Id);
        }

    }
}
