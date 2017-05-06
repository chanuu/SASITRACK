using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Operations.DTOs;
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
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.Operations
{
    class OperationPoolAppService: ITrackERPAppServiceBase, IOperationPoolAppService
    {
        private readonly IRepository<OperationPool, Guid> _operationPoolRepository;

        public OperationPoolAppService(IRepository<OperationPool, Guid> operationPoolRepository)
        {
            _operationPoolRepository = operationPoolRepository;
        }

        public ListResultOutput<OperationPoolListDto> GetOperations() 
        {
            var operations = _operationPoolRepository.GetAll().ToList();

            return new ListResultOutput<OperationPoolListDto>(operations.MapTo<List<OperationPoolListDto>>());
        }

        public OperationPoolDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @operation = _operationPoolRepository
                .GetAll()
                .Include(x => x.FolderDetails)
                .Include(x => x.FootDetails)
                .Include(x => x.AttatchmentDetails)
                .Include(x => x.NeedleDetails)
                .Include(x => x.ThreadDetails)
                .Include(x => x.WorkCycleImages)
                .Include(x => x.WorkCycleVideos)
                
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@operation == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @operation.MapTo<OperationPoolDto>();
        }

        public async Task Create(CreateOperationPoolDto input)
        {
            var @operation = input.MapTo<OperationPool>();
            @operation = OperationPool.Create(AbpSession.GetTenantId(), input.OperationCode, input.OperationName, input.MachineType, input.SMV, input.SMVType, input.Remark, input.PartName, input.OperationRole,
                input.OperationGrade, input.MachineSpeed, input.SeamLength, input.SeamAllowance, input.SPI);
            await _operationPoolRepository.InsertAsync(@operation);

        }

        public async Task Update(EditOperationPoolDto input)
        {
            var @operation = input.MapTo<OperationPool>();
            @operation.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _operationPoolRepository.UpdateAsync(@operation);
        }
        public async Task DeleteOperation(DeleteOperationPoolDto input)
        {
            var @operation = input.MapTo<OperationPool>();

            await _operationPoolRepository.DeleteAsync(@operation.Id);
        }

    }
}
