using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;


namespace ITrackERP.Company
{
    public class CutPlan : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }


        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string CutPlanNo { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string FabricType { get; set; }

        public virtual string Color { get; set; }

        public virtual string NoOfplys { get; set; }

        public virtual int Total { get; set; }

        public virtual string LineNo { get; set; }

        public virtual string Start { get; set; }

        public virtual string End { get; set; }

        public virtual string TableNo { get; set; }

        public virtual string TeamLeader { get; set; }

        public virtual string Status { get; set; }

       

        public static CutPlan Create(int tenantId, string cutPlanNo, DateTime date, string fabricType, string color, string noOfPlys,
            int total, string lineNo, string start, string end, string tableNo, string teamLeader, string status)

        {
            var @cutplan = new CutPlan()
            {
                Id = Guid.NewGuid(),
                CutPlanNo = cutPlanNo,
                Date = date,
                FabricType = fabricType,
                Color = color,
                NoOfplys = noOfPlys,
                Total = total,
                LineNo = lineNo,
                Start = start,
                End = end,
                TableNo = tableNo,
                TeamLeader = teamLeader,
                Status = status,





            };

            

            return @cutplan;





        }




    }
}
