using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.CustomeFiledSetups.Dto;
using ITrackERP.CustomeFiledSetup.Dto;

namespace ITrackERP.CustomeFiledSetups
{
    public interface ICustomeFieldSetupAppService : IApplicationService
    {
        ListResultOutput<CustomeFieldSetupListDto> GetCustomeFieldSetup();

        CustomeFieldSetupDetailDto GetDetail(EntityResultOutput<Guid> input);

        CustomeFieldSetupDetailDto GetDetailByName(CustomeFieldItemTypeInputDto input);

        Task Create(CreateCustomeFieldSetupInputDto input);

        Task Update(EditCustomeFieldSetupDto input);

        Task Delete(DeleteCustomFieldSetupDto input);

    }
}
