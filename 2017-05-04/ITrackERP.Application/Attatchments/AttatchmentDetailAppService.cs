using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Attatchments.DTOs;
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

namespace ITrackERP.Attatchments
{
    public class AttatchmentDetailAppService : ITrackERPAppServiceBase, IAttatchmentDetailAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<AttatchmentDetail, Guid> _attatchmentDetailRepository;

       public AttatchmentDetailAppService(IRepository<OperationPool, Guid> operationPoolRepository, IRepository<AttatchmentDetail, Guid> attatchmentDetailRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _attatchmentDetailRepository = attatchmentDetailRepository;
       }


       public AttatchmentDetailDto GetAttatchmentDetailsByID(EntityRequestInput<Guid> input)
       {
           var @attatchmentdetail = _attatchmentDetailRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @attatchmentdetail.MapTo<AttatchmentDetailDto>();

       }

       public async Task CreateAttatchmentDetail(CreateAttatchmentDetailDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @attatchmentDetail = input.MapTo<AttatchmentDetail>();

           @attatchmentDetail.TenantId = AbpSession.GetTenantId();

           @attatchmentDetail = AttatchmentDetail.Create(input.AttatchmentType, input.Remark);

           header.AttatchmentDetails.Add(@attatchmentDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateAttatchmentDetail(EditAttatchmentDetailDto input)
       {
           var @attatchmentDetail = input.MapTo<AttatchmentDetail>();
           @attatchmentDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _attatchmentDetailRepository.UpdateAsync(@attatchmentDetail);
       }

       public async Task DeleteAttatchmentDetail(DeleteAttatchmentDetailDto input)
       {
           var @attatchmentDetail = input.MapTo<AttatchmentDetail>();

           await _attatchmentDetailRepository.DeleteAsync(@attatchmentDetail.Id);
       }


    }
}
