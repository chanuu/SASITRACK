using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.MachineTypes.DTOs;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace ITrackERP.MachineTypes
{ 
    public class MachineTypeAppService : ITrackERPAppServiceBase, IMachineTypeAppService
    {
        private readonly IRepository<MachineType, Guid> _machineTypeRepository;

        public MachineTypeAppService(IRepository<MachineType, Guid> machineTypeRepository)
        {
            _machineTypeRepository = machineTypeRepository;
        }

        public ListResultOutput<MachineTypeListDto> GetMachineTypes() 
        {
            var machinetypes = _machineTypeRepository.GetAll().ToList();

            return new ListResultOutput<MachineTypeListDto>(machinetypes.MapTo<List<MachineTypeListDto>>());
        }

        public MachineTypeDetailOutputDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @machinetype = _machineTypeRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@machinetype == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @machinetype.MapTo<MachineTypeDetailOutputDto>();
        }


        public MachineTypeDetailOutputDto GetDetailByMachineType(MachineTypeNameInputDto input)
        {
            var @machinetype = _machineTypeRepository
                .GetAll()
                .Where(e => e.MachineTypeName == input.MachineTypeName)
                .ToList().FirstOrDefault();

            return @machinetype.MapTo<MachineTypeDetailOutputDto>();
        }

        public async Task Create(CreateMachineTypeDto input)
        {
            var @machinetype = input.MapTo<MachineType>();
            @machinetype = MachineType.Create(AbpSession.GetTenantId(), input.MachineTypeName, input.Category1, input.Category2, input.Remark);
            await _machineTypeRepository.InsertAsync(@machinetype);

        }

        public async Task Update(EditMachineTypeDto input)
        {
            var @machinetype = input.MapTo<MachineType>();
            @machinetype.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _machineTypeRepository.UpdateAsync(@machinetype);
        }
        public async Task DeleteMachineType(DeleteMachineTypeDto input)
        {
            var @machinetype = input.MapTo<MachineType>();

            await _machineTypeRepository.DeleteAsync(@machinetype.Id);
        }

    }
}

