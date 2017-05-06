using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Buyer
{
    public class BuyerProfile : FullAuditedEntity<Guid>, IMustHaveTenant
    {


        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;


        public virtual int TenantId { get; set; }

        public virtual string BuyerName { get; protected set; }

        public virtual string TeleNo { get; protected set; }

        public virtual string Address { get; protected set; }


        public virtual string Email { get; protected set; }

        public virtual string Remark { get; protected set; }


      public static   BuyerProfile Create(int tanentId, string buyerName, string teleNo, string address, string email, string remark ) {

            var @buyer = new BuyerProfile
            {
                Id = Guid.NewGuid(),
                TenantId = tanentId,
                BuyerName = buyerName,
                TeleNo = teleNo,
                Address = address,
                Email = email,
                Remark = remark


            };
            return @buyer;

        }

       


    }
}
