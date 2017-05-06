using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Rent_Machines.DTOs
{
    [AutoMap(typeof(RentMachine))]
    public class DeleteRentMachineDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
