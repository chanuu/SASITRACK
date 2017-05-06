using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CustomeFiledSetups.Dto
{
     [AutoMap(typeof(Master.CustomeFiledSetup))]
    public class DeleteCustomFieldSetupDto : FullAuditedEntityDto<Master.CustomeFiledSetup>
    {
         public Guid Id { get; set; }
    }
}
