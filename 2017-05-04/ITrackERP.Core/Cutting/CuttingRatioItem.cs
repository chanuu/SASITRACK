using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITRACK.Cutting
{
    public class CuttingRatioItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        [ForeignKey("CuttingRatioId")]

        public virtual CuttingRatio CuttingRatio { get; set; }

        public virtual Guid CuttingRatioId { get; set; }

        public virtual string Size { get; set; }

        public virtual int Lot { get; set; }

        public virtual int TenantId { get; set; }


        public static CuttingRatioItem Create(string _size, int _lot)
        {
            var @item = new CuttingRatioItem
            {
                Size = _size,
                Lot = _lot,
                Id = Guid.NewGuid()
            };
            return @item;
        }
    }

   
}
