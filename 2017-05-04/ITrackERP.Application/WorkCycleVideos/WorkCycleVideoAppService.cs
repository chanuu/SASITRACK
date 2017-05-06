using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.TAW;
using ITrackERP.WorkCycleVideos.DTOs;
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

namespace ITrackERP.WorkCycleVideos
{
    public class WorkCycleVideoAppService : ITrackERPAppServiceBase, IWorkCycleVideoAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<WorkCycleVideo, Guid> _workCycleVideoRepository;

       public WorkCycleVideoAppService(IRepository<OperationPool, Guid> operationPoolRepository, IRepository<WorkCycleVideo, Guid> workCycleVideoRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _workCycleVideoRepository = workCycleVideoRepository;
       }


       public WorkCycleVideoDto GetWorkCycleVideoDetailsByID(EntityRequestInput<Guid> input)
       {
           var @workCycleVideodetail = _workCycleVideoRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @workCycleVideodetail.MapTo<WorkCycleVideoDto>();

       }

       public async Task CreateWorkCycleVideo(CreateWorkCycleVideoDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @workCycleVideoDetail = input.MapTo<WorkCycleVideo>();

           @workCycleVideoDetail.TenantId = AbpSession.GetTenantId();

           @workCycleVideoDetail = WorkCycleVideo.Create(input.WorkCycleVideoPath, input.Remark);

           header.WorkCycleVideos.Add(@workCycleVideoDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateWorkCycleVideo(EditWorkCycleVideoDto input)
       {
           var @workCycleVideoDetail = input.MapTo<WorkCycleVideo>();
           @workCycleVideoDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _workCycleVideoRepository.UpdateAsync(@workCycleVideoDetail);
       }

       public async Task DeleteWorkCycleVideo(DeleteWorkCycleVideoDto input)
       {
           var @workCycleVideoDetail = input.MapTo<WorkCycleVideo>();

           await _workCycleVideoRepository.DeleteAsync(@workCycleVideoDetail.Id);
       }


    }
}
