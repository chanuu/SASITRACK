using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.TAW;
using ITrackERP.WorkCycleImages.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.WorkCycleImages
{
    public class WorkCycleImageAppService : ITrackERPAppServiceBase, IWorkCycleImageAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<WorkCycleImage, Guid> _workCycleImageRepository;

       public WorkCycleImageAppService(IRepository<OperationPool, Guid> operationPoolRepository, IRepository<WorkCycleImage, Guid> workCycleImageRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _workCycleImageRepository = workCycleImageRepository;
       }


       public WorkCycleImageDto GetWorkCycleImageDetailsByID(EntityRequestInput<Guid> input)
       {
           var @workCycleImagedetail = _workCycleImageRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @workCycleImagedetail.MapTo<WorkCycleImageDto>();

       }

       public async Task CreateWorkCycleImage(CreateWorkCycleImageDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @workCycleImageDetail = input.MapTo<WorkCycleImage>();

           @workCycleImageDetail.TenantId = AbpSession.GetTenantId();

           @workCycleImageDetail = WorkCycleImage.Create(input.WorkCycleImagePath, input.Remark);

           header.WorkCycleImages.Add(@workCycleImageDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateWorkCycleImage(EditWorkCycleImageDto input)
       {
           var @workCycleImageDetail = input.MapTo<WorkCycleImage>();
           @workCycleImageDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _workCycleImageRepository.UpdateAsync(@workCycleImageDetail);
       }

       public async Task DeleteWorkCycleImage(DeleteWorkCycleImageDto input)
       {
           var @workCycleImageDetail = input.MapTo<WorkCycleImage>();

           await _workCycleImageRepository.DeleteAsync(@workCycleImageDetail.Id);
       }


    }
}
