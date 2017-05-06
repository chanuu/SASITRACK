using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Production
{
  public  class DailyProductionSummary : FullAuditedEntity<Guid>, IMustHaveTenant
    {

        public virtual int TenantId { get; set; }

        public virtual string DayendID { get; set; }

      
        public virtual DateTime Date { get; set; }

       
        public virtual string LineNo { get; set; }

       
        public virtual string StyleNo { get; set; }

        public string PoNo { get; set; }

        public virtual string Color { get; set; }
      
        public virtual string Size { get; set; }

        public virtual string Length { get; set; }

        public virtual int CutQty { get; set; }

        public virtual int LineIn { get; set; }

        public virtual int LineInCumm { get; set; }

        public int LineInTotal { get; set; }

        public virtual int LineOut { get; set; }

        public virtual int LineOutCumm { get; set; }

        public int LineOutTotal { get; set; }

    }
}
