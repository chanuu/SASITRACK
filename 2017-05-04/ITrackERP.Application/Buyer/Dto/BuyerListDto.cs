using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Buyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.BuyerProfiles.Dto
{
    [AutoMapFrom(typeof(BuyerProfile))]
 public  class BuyerProfileListDto:FullAuditedEntityDto<Guid>
    {
        public  string BuyerName { get; protected set; }

        public  string TeleNo { get; protected set; }

        public  string Address { get; protected set; }


        public  string Email { get; protected set; }

        public  string Remark { get; protected set; }
    }
}
