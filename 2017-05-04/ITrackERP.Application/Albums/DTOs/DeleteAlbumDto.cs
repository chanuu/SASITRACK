using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Albums.DTOs
{
     [AutoMap(typeof(Album))]
    public class DeleteAlbumDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
