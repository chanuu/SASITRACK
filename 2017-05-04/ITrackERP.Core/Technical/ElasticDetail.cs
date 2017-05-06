using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Technical
{
    public class ElasticDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }
        public virtual Guid StyleId { get; set; }



        public virtual string FabricColour { get; set; }
        
        public virtual string ElasticColour { get; set; }

        public virtual string Cumption { get; set; }

        public virtual double Width { get; set; }

        public virtual string Remark { get; set; }


        public static ElasticDetail Create(string fabricColour, string elasticColour, string cumption, double width, string remark)
        {
            var @elasticdetail = new ElasticDetail
            {
                Id = Guid.NewGuid(),
                FabricColour = fabricColour,
                ElasticColour = elasticColour,
                Cumption = cumption,
                Width = width,
                Remark = remark,
            };


            return @elasticdetail;



        }

    }
}
