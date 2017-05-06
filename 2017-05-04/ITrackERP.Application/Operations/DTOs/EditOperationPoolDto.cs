using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Operations.DTOs
{
    [AutoMap(typeof(OperationPool))]
    public class EditOperationPoolDto : FullAuditedEntityDto<Guid>
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

    }
}
