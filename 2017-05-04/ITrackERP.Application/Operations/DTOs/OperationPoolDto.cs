using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Attatchments.DTOs;
using ITrackERP.FolderDetails.DTOs;
using ITrackERP.FootDetails.DTOs;
using ITrackERP.NeedleDetails.DTOs;
using ITrackERP.TAW;
using ITrackERP.ThreadDetails.DTOs;
using ITrackERP.WorkCycleImages.DTOs;
using ITrackERP.WorkCycleVideos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Operations.DTOs
{
     [AutoMapFrom(typeof(OperationPool))]

    public class OperationPoolDto : FullAuditedEntityDto<Guid>
    {
        public string OperationCode { get; set; }

        public string OperationName { get; set; }

        public string MachineType { get; set; }

        public double SMV { get; set; }

        public string SMVType { get; set; }

        public string Remark { get; set; }

        public string PartName { get; set; }

        public string OperationRole { get; set; }

        public string OperationGrade { get; set; }

        public string MachineSpeed { get; set; }

        public string SeamLength { get; set; }

        public string SeamAllowance { get; set; }

        public string SPI { get; set; }

        
        public ICollection<FolderDetailDto> FolderDetails { get; set; }

        public ICollection<FootDetailDto> FootDetails { get; set; }

        public ICollection<NeedleDetailDto> NeedleDetails { get; set; }
        public ICollection<ThreadDetailDto> ThreadDetails { get; set; }

        public ICollection<AttatchmentDetailDto> AttatchmentDetails { get; set; }

        public ICollection<WorkCycleImageDto> WorkCycleImages { get; set; }
        public ICollection<WorkCycleVideoDto> WorkCycleVideos { get; set; }

    }
}
