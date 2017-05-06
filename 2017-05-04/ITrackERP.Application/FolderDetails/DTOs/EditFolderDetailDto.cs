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
    public class EditFolderDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }
        public string FolderType { get; set; }
        public string Remark { get; set; }
    }
}
