using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITRACK.Costing;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using ITrackERP.Buyer;
using ITRACK.Cutting;
using ITrackERP.Technical;
using ITrackERP.TAW;

namespace ITRACK.Company
{
    public  class Style : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        
        public virtual int TenantId { get; set; }


      

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string StyleNo { get; protected set; }

        public virtual string ArticleNo { get; protected set; }


        public virtual string Season { get; protected set; }

        public virtual string Remark { get; protected set; }

        public virtual string OrderType { get; set; }

        public virtual string Department { get; set; }

        [Required]
        public virtual string BocNo { get; set; }

        public virtual string ItemType { get; set; }

        [Required]
       

        public virtual string BuyerName { get; set; }

        public virtual string ImagePath { get; set; }

        public virtual ICollection<WorkOrderHeader> WorkOrders { get; set; }

        public virtual ICollection<CuttingRatio> CuttingRatio { get; set; }

        public virtual ICollection<FabricDetail> FabricDetails { get; set; }
        public virtual ICollection<ElasticDetail> ElasticDetails { get; set; }
        public virtual ICollection<ZipperDetail> ZipperDetails { get; set; }
        public virtual ICollection<SewingThreadAndNeedleDetail> SewingThreadAndNeedleDetails { get; set; }

        public virtual ICollection<DividingPlanHeader> DividingPlanHeaders { get; set; }

        public static Style Create(int tenantId, string styleNo, string articleNo, string season , string remark,string orderType,string department,string bocNo,string itemType,string buyerId)
        {
            var @style = new Style
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                StyleNo= styleNo,
                ArticleNo = articleNo,
                Season = season,
                Remark = remark,
                OrderType = orderType,
                Department= department,
                BocNo = bocNo,
                ItemType = itemType,
                BuyerName = buyerId
            };


            @style.WorkOrders = new Collection<WorkOrderHeader>();
            @style.FabricDetails = new Collection<FabricDetail>();
            @style.ElasticDetails = new Collection<ElasticDetail>();
            @style.ZipperDetails = new Collection<ZipperDetail>();
            @style.SewingThreadAndNeedleDetails = new Collection<SewingThreadAndNeedleDetail>();
            @style.DividingPlanHeaders = new Collection<DividingPlanHeader>();

            return @style;
        }





    }
}
