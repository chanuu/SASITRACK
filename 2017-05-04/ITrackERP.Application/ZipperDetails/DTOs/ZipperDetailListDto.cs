using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ZipperDetails.DTOs
{
    public class GetZipperDetailInput
    {
        public Guid Id { get; set; }
    }

   [AutoMap(typeof(ZipperDetail))]

   public class ZipperDetailListDto : FullAuditedEntityDto<Guid>
   {
       // public string Style { get; set; }
       public Guid StyleId { get; set; }

       public string FabricColour { get; set; }

       public string ZipperColour { get; set; }

       public double ZipperLength { get; set; }

       public string Size { get; set; }

       public string Remark { get; set; }
   }
}
