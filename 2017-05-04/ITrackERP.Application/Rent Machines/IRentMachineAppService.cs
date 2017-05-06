using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Rent_Machines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Rent_Machines
{
    public interface IRentMachineAppService : IApplicationService
    {
        ListResultOutput<RentMachineListDto> GetRentMachines();

        RentMachineDetailOutputDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateRentMachineDto input);

        Task Update(EditRentMachineDto input);

        Task UpdateStatus(EntityResultOutput<Guid> input);

        Task DeleteRentMachine(DeleteRentMachineDto input);
    }
}
