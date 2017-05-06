using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FolderDetails.DTOs
{

    [AutoMap(typeof(FolderDetail))]
    public class CreateFolderDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }

        [Required]
        public string FolderType { get; set; }

        [MaxLength(100)]
        public string Remark { get; set; }
    }
}