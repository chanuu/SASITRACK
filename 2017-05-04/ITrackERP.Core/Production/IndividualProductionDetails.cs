using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Production
{
  public  class IndividualProductionDetails : FullAuditedEntity<Guid>, IMustHaveTenant
    {

        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get; set; }
        public string EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string StyleNo { get; set; }

        public string PoNo { get; set; }


        public DateTime Date { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int HourNo { get; set; }

        public int WorkstationNo { get; set; }

        public string OperationNo { get; set; }

        public string LineNo { get; set; }

        public string Module { get; set; }


        public string OperationName { get; set; }

        public string OperationRole { get; set; }
        public int Pcs { get; set; }

        public double SMV { get; set; }


        public double SAH { get; set; }

        public double Efficiency { get; set; }
    }
}
