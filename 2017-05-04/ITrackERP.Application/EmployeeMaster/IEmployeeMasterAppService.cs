using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.EmployeeMaster.Dto;

namespace ITrackERP.EmployeeMaster
{
    public interface IEmployeeMasterAppService : IApplicationService
    {
        ListResultOutput<EmployeeListDto> GetEmployeeMaster();

        EmployeeMasterDetailOutput GetDetail(EntityRequestInput<Guid> input);

        Task Create(CreateEmployeeMasterInputDto input);

    }
}
