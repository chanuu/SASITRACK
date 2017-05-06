using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITRACK.Company;
using ITRACK.Costing;
using ITrackERP.Buyer;
using ITrackERP.FabricDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Styles.Dto
{

    [AutoMapFrom(typeof(Style))]
    public class StyleListDto : FullAuditedEntityDto<Guid>
    {
        public string StyleNo { get; set; }

        public string OrderType { get; set; }

        public  string ArticleNo { get;  set; }

        public  string Season { get;  set; }

        public  string BocNo { get; set; }

        public  string ItemType { get; set; }

        public  string Department { get; set; }

        public  string Remark { get; set; }

       

       


    }

    [AutoMapFrom(typeof(Style))]
    public class StyleDetailOutputDto : FullAuditedEntityDto<Guid>
    {
        public string StyleNo { get; set; }

        public string OrderType { get; set; }

        public string ArticleNo { get; protected set; }

        public string Season { get; protected set; }

        public string BocNo { get; set; }

        public string Department { get; set; }

        public string ItemType { get; set; }

        public string Remark { get; protected set; }

        public string BuyerName { get; set; }

        public ICollection<FabricDetailListDto> FabricDetails { get; set; }
    }


    [AutoMap(typeof(Style))]
    public class StyleNoInputDto : FullAuditedEntityDto<Guid>
    {
        public string StyleNo { get; set; }
    }

}
