using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.NeedleDetails.DTOs;
using ITrackERP.TAW;
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

namespace ITrackERP.NeedleDetails
{
    public class NeedleDetailAppService: ITrackERPAppServiceBase, INeedleDetailAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<NeedleDetail, Guid> _needleDetailRepository;

       public NeedleDetailAppService(IRepository<OperationPool, Guid> operationPoolRepository, IRepository<NeedleDetail, Guid> needleDetailRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _needleDetailRepository = needleDetailRepository;
       }


       public NeedleDetailDto GetNeedleDetailsByID(EntityRequestInput<Guid> input)
       {
           var @needledetail = _needleDetailRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @needledetail.MapTo<NeedleDetailDto>();

       }

       public async Task CreateNeedleDetail(CreateNeedleDetailDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @needleDetail = input.MapTo<NeedleDetail>();

           @needleDetail.TenantId = AbpSession.GetTenantId();

           @needleDetail = NeedleDetail.Create(input.NeedleType, input.Remark);

           header.NeedleDetails.Add(@needleDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateNeedleDetail(EditNeedleDetailDto input)
       {
           var @needleDetail = input.MapTo<NeedleDetail>();
           @needleDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _needleDetailRepository.UpdateAsync(@needleDetail);
       }

       public async Task DeleteNeedleDetail(DeleteNeedleDetailDto input)
       {
           var @needleDetail = input.MapTo<NeedleDetail>();

           await _needleDetailRepository.DeleteAsync(@needleDetail.Id);
       }


    }
}
