using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Assets;
using ITrackERP.Rent_Machines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace ITrackERP.Rent_Machines
{
    public class RentMachineAppService : ITrackERPAppServiceBase, IRentMachineAppService
    {
        private readonly IRepository<RentMachine, Guid> _rentMachineRepository;

        public RentMachineAppService(IRepository<RentMachine, Guid> rentMachineRepository)
        {
            _rentMachineRepository = rentMachineRepository;
        }

        public ListResultOutput<RentMachineListDto> GetRentMachines() 
        {
            var rentmachines = _rentMachineRepository.GetAll().ToList();

            return new ListResultOutput<RentMachineListDto>(rentmachines.MapTo<List<RentMachineListDto>>());
        }

        public RentMachineDetailOutputDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @rentmachine = _rentMachineRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@rentmachine == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @rentmachine.MapTo<RentMachineDetailOutputDto>();
        }

        public async Task Create(CreateRentMachineDto input)
        {
            var @rentmachine = input.MapTo<RentMachine>();
            @rentmachine = RentMachine.Create(AbpSession.GetTenantId(), input.RentManagementID, input.MachineType, input.MachineSerialNo,
                input.RentBarcode, input.FromDate.Value, input.ToDate.Value, input.Remark, input.Status);
            await _rentMachineRepository.InsertAsync(@rentmachine);

        }

        public async Task Update(EditRentMachineDto input)
        {
            var @rentmachine = input.MapTo<RentMachine>();
            @rentmachine.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _rentMachineRepository.UpdateAsync(@rentmachine);
        }

        public async Task UpdateStatus(EntityResultOutput<Guid> input)
        {
            var @rentmachine = _rentMachineRepository.Get(input.Id);

            @rentmachine.TenantId = AbpSession.GetTenantId();

            @rentmachine.Status = "Return";
            int i = 0;
            await _rentMachineRepository.UpdateAsync(@rentmachine);
        }
        public async Task DeleteRentMachine(DeleteRentMachineDto input)
        {
            var @rentmachine = input.MapTo<RentMachine>();

            await _rentMachineRepository.DeleteAsync(@rentmachine.Id);
        }

    }
}
