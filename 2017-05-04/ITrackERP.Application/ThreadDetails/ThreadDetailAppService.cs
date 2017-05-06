using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.TAW;
using ITrackERP.ThreadDetails.DTOs;
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

namespace ITrackERP.ThreadDetails
{
    public class ThreadDetailAppService: ITrackERPAppServiceBase, IThreadDetailAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<ThreadDetail, Guid> _threadDetailRepository;

       public ThreadDetailAppService(IRepository<OperationPool, Guid> operationPoolRepository, IRepository<ThreadDetail, Guid> threadDetailRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _threadDetailRepository = threadDetailRepository;
       }


       public ThreadDetailDto GetThreadDetailsByID(EntityRequestInput<Guid> input)
       {
           var @threaddetail = _threadDetailRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @threaddetail.MapTo<ThreadDetailDto>();

       }

       public async Task CreateThreadDetail(CreateThreadDetailDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @threadDetail = input.MapTo<ThreadDetail>();

           @threadDetail.TenantId = AbpSession.GetTenantId();

           @threadDetail = ThreadDetail.Create(input.ThreadType, input.Remark);

           header.ThreadDetails.Add(@threadDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateThreadDetail(EditThreadDetailDto input)
       {
           var @threadDetail = input.MapTo<ThreadDetail>();
           @threadDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _threadDetailRepository.UpdateAsync(@threadDetail);
       }

       public async Task DeleteThreadDetail(DeleteThreadDetailDto input)
       {
           var @threadDetail = input.MapTo<ThreadDetail>();

           await _threadDetailRepository.DeleteAsync(@threadDetail.Id);
       }


    }
}
