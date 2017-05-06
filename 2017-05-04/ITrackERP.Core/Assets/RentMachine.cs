using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets
{
    public class RentMachine : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string RentManagementID { get; set; }

        public virtual string MachineType { get; set; }

        public virtual string MachineSerialNo { get; set; }

        public virtual string RentBarcode { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

        public virtual string Remark { get; set; }
        public virtual string Status { get; set; }

        public static RentMachine Create(int tenantId, string rentManagementID, string machineType, string machineSerialNo,
           string rentBarcode, DateTime fromDate, DateTime toDate, string remark, string status)

        {
            var rentmachine = new RentMachine
            {
                Id = Guid.NewGuid(),
                RentManagementID = rentManagementID,
                MachineType = machineType,
                MachineSerialNo = machineSerialNo,
                RentBarcode = rentBarcode,
                FromDate = fromDate,
                ToDate = toDate,
                Remark = remark,
                Status = status
            }; 

            return @rentmachine;
        }
    }
}
