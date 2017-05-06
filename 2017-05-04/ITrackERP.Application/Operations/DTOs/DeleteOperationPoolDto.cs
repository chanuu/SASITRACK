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
    public class DeleteOperationPoolDto: FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
