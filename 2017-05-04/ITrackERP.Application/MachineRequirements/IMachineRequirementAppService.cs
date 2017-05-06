using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.MachineRequirements.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements
{
    public interface IMachineRequirementAppService: IApplicationService
    {
        ListResultOutput<MachineRequirementListDto> GetMachineRequirement();

        ListResultOutput<MachineRequirementItemListDto> GetMachineRequirementItems(MachineRequirementIdInputDto input);
        MachineRequirementDto GetDetail(EntityRequestInput<Guid> input);

        MachineRequirementItemDto GetMachineRequirementItemByID(EntityRequestInput<Guid> input);

        ListResultOutput<MachineRequrementItemByStyleDto> GetMachineRequirementItemByDate(filterInput input);

        Task DuplicateEvent(CreateMachineRequirementDto input);
        Task CreateHeader(CreateMachineRequirementDto input);

        Task UpdateHeader(EditMachineRequirementDto input);

        Task DeleteHeader(DeleteMachineRequirementDto input);

        Task UpdateItem(EditMachineRequirementItemDto input);

        Task CreateItem(CreateMachineRequirementItemDto input);

        Task DeleteItem(DeleteMachineRequirementItemDto input);
    
    }
}
