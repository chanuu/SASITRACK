using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Buyer.Dto
{

    [AutoMap(typeof(BuyerProfile))]
    public  class CreateBuyerProfileInputDto 
    {
       
        public string BuyerName { get;  set; }
        
        public string TeleNo { get;  set; }

        public string Address { get; set; }

        
        public string Email { get;  set; }

        public string Remark { get;  set; }
    }
}
