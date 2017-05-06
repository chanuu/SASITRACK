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
    public class EditRentMachineDto : FullAuditedEntityDto<Guid>
    {
        public string RentManagementID { get; set; }

        public string MachineType { get; set; }

        public string MachineSerialNo { get; set; }

        public string RentBarcode { get; set; }

        public Nullable<DateTime> FromDate { get; set; }

        public Nullable<DateTime> ToDate { get; set; }

        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
