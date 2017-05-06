using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;

namespace ITRACK.Cutting
{
    public class CuttingRatio : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;


        public int TenantId { get; set; }


        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }
        public virtual string RatioNo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Length { get; set; }

        public virtual double MarkerLength { get; set; }

        public virtual double MarkerWidth { get; set; }

        public virtual double LayerLength { get; set; }

        public virtual string FabricType { get; set; }

        public virtual string Remark { get; set; }


        public virtual ICollection<CuttingRatioItem> CuttingRatioItem { get; set; }


        public static CuttingRatio Create(int tenantId,Guid styleId, string ratioNo,string color,string length,double markerLength,double markerWidth,double layerLength,string fabricType,string remark) {

           var @ratio = new CuttingRatio
            {
                TenantId = tenantId,
                StyleId = styleId,
                RatioNo = ratioNo,
                Color = color,
                Length = length,
                MarkerLength = markerLength,
                MarkerWidth = markerWidth,
                LayerLength = layerLength,
                FabricType = fabricType,
                Remark = remark
            };

            return @ratio;

        }



    }

}
