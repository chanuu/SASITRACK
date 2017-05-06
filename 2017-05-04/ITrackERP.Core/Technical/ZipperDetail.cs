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
    public class ZipperDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }
        public virtual Guid StyleId { get; set; }



        public virtual string FabricColour { get; set; }

        public virtual string ZipperColour { get; set; }

        public virtual double ZipperLength { get; set; }

        public virtual string Size { get; set; }

        public virtual string Remark { get; set; }


        public static ZipperDetail Create(string fabricColour, string zipperColour, double zipperLength, string size, string remark)
        {
            var @zipperdetail = new ZipperDetail
            {
                Id = Guid.NewGuid(),
                FabricColour = fabricColour,
                ZipperColour = zipperColour,
                ZipperLength = zipperLength,
                Size = size,
                Remark = remark,
            };


            return @zipperdetail;



        }

    }
}
