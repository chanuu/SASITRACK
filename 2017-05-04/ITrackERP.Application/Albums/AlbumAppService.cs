using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.Albums.DTOs;
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

namespace ITrackERP.Albums
{
    public class AlbumAppService : ITrackERPAppServiceBase, IAlbumAppService
    {
        private readonly IRepository<Album, Guid> _albumRepository;
        private readonly IRepository<EventHeader, Guid> _eventHeaderRepository;

        // this is test commit for testing Github Functionality 
        public AlbumAppService(IRepository<Album, Guid> albumRepository, IRepository<EventHeader, Guid> eventHeaderRepository)
        {
            _albumRepository = albumRepository;
            _eventHeaderRepository = eventHeaderRepository;
        }

        public ListResultOutput<AlbumListDto> GetAll() 
        {
            var albums = _albumRepository.GetAll().ToList();

            return new ListResultOutput<AlbumListDto>(albums.MapTo<List<AlbumListDto>>());
        }

        public AlbumDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @album = _albumRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@album == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @album.MapTo<AlbumDto>();
        }

        public async Task Create(CreateAlbumDto input)
        {
            var @eventHeader = _eventHeaderRepository.Get(input.EventHeaderId);

            var @album = input.MapTo<Album>();
            @album = Album.Create(AbpSession.GetTenantId(), input.Name, input.Url);

            @eventHeader.Albums.Add(@album);

            await CurrentUnitOfWork.SaveChangesAsync();


        }

        public async Task Update(EditAlbumDto input)
        {
            var @album = input.MapTo<Album>();
            @album.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _albumRepository.UpdateAsync(@album);
        }
        public async Task Delete(DeleteAlbumDto input)
        {
            var @album = input.MapTo<Album>();

            await _albumRepository.DeleteAsync(@album.Id);
        }

    }
}
