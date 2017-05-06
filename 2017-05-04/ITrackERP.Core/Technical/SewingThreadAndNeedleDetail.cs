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
    public class SewingThreadAndNeedleDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }
        public virtual Guid StyleId { get; set; }



        public virtual string SeamType { get; set; }

        public virtual string SPI { get; set; }

        public virtual string TKTNo { get; set; }

        public virtual string NeedleType { get; set; }

        public virtual string NeedleSize { get; set; }

        public virtual string Remark { get; set; }


        public static SewingThreadAndNeedleDetail Create(string seamType, string sPI, string tKTNo,string needleType, string needleSize, string remark)
        {
            var @sewingThreadAndNeedleDetail = new SewingThreadAndNeedleDetail
            {
                Id = Guid.NewGuid(),
                SeamType = seamType,
                SPI = sPI,
                TKTNo = tKTNo,
                NeedleType = needleType,
                NeedleSize =needleSize,
                Remark = remark,
            };


            return @sewingThreadAndNeedleDetail;



        }

    }
}
