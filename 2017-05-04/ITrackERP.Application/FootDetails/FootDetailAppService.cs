using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.FootDetails.DTOs;
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

namespace ITrackERP.FootDetails
{
    public class FootDetailAppService: ITrackERPAppServiceBase, IFootDetailAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<FootDetail, Guid> _footDetailRepository;

       public FootDetailAppService(IRepository<OperationPool, Guid> operationPoolRepository,IRepository<FootDetail, Guid> footDetailRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _footDetailRepository = footDetailRepository;
       }

      
       public FootDetailDto GetFootDetailsByID(EntityRequestInput<Guid> input)
       {
           var @footdetail = _footDetailRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @footdetail.MapTo<FootDetailDto>();

       }

       public async Task CreateFootDetail(CreateFootDetailDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @footDetail = input.MapTo<FootDetail>();

           @footDetail.TenantId = AbpSession.GetTenantId();

           @footDetail = FootDetail.Create(input.FootType, input.Remark);

           header.FootDetails.Add(@footDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateFootDetail(EditFootDetailDto input)
       {
           var @footDetail = input.MapTo<FootDetail>();
           @footDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _footDetailRepository.UpdateAsync(@footDetail);
       }

       public async Task DeleteFootDetail(DeleteFootDetailDto input)
       {
           var @footDetail = input.MapTo<FootDetail>();

           await _footDetailRepository.DeleteAsync(@footDetail.Id);
       }


    }
}
