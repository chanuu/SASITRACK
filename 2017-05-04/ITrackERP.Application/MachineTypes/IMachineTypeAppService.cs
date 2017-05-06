using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.MachineTypes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineTypes
{
    public interface IMachineTypeAppService : IApplicationService
    {
        ListResultOutput<MachineTypeListDto> GetMachineTypes();

        MachineTypeDetailOutputDto GetDetail(EntityResultOutput<Guid> input);

        MachineTypeDetailOutputDto GetDetailByMachineType(MachineTypeNameInputDto input);
        Task Create(CreateMachineTypeDto input);

        Task Update(EditMachineTypeDto input);

        Task DeleteMachineType(DeleteMachineTypeDto input);
    }
}
