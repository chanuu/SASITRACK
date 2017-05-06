using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FolderDetails.DTOs
{
    [AutoMap(typeof(FolderDetail))]

    public class DeleteFolderDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
