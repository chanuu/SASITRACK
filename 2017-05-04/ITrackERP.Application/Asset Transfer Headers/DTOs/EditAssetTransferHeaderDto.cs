using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Transfer_Headers.DTOs
{
    [AutoMap(typeof(AssetTransferHeader))]
    public class EditAssetTransferHeaderDto : FullAuditedEntityDto<Guid>
    {
        public string TransferNoteNo { get; set; }
        public string RequisitionNo { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TransferBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
