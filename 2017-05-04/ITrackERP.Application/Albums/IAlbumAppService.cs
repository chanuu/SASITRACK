using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Albums.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Albums
{
    public interface IAlbumAppService : IApplicationService
    {
        AlbumDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateAlbumDto input);

        Task Update(EditAlbumDto input);

        Task Delete(DeleteAlbumDto input);
    }
}
