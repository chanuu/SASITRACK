using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.FolderDetails.DTOs;
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

namespace ITrackERP.FolderDetails
{
    public class FolderDetailAppService : ITrackERPAppServiceBase, IFolderDetailAppService
    {
       private readonly IRepository<OperationPool, Guid> _operationPoolRepository;
       private readonly IRepository<FolderDetail, Guid> _folderDetailRepository;

       public FolderDetailAppService(IRepository<OperationPool, Guid> operationPoolRepository,IRepository<FolderDetail, Guid> folderDetailRepository)
           
       {
           _operationPoolRepository = operationPoolRepository;
           _folderDetailRepository = folderDetailRepository;
       }

      
       public FolderDetailDto GetFolderDetailsByID(EntityRequestInput<Guid> input)
       {
           var @folderdetail = _folderDetailRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @folderdetail.MapTo<FolderDetailDto>();

       }

       public async Task CreateFolderDetail(CreateFolderDetailDto input)
       {
           var header = _operationPoolRepository.Get(input.OperationPoolId);

           var @folderDetail = input.MapTo<FolderDetail>();

           @folderDetail.TenantId = AbpSession.GetTenantId();

           @folderDetail = FolderDetail.Create(input.FolderType, input.Remark);

           header.FolderDetails.Add(@folderDetail);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateFolderDetail(EditFolderDetailDto input)
       {
           var @folderDetail = input.MapTo<FolderDetail>();
           @folderDetail.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _folderDetailRepository.UpdateAsync(@folderDetail);
       }

       public async Task DeleteFolderDetail(DeleteFolderDetailDto input)
       {
           var @folderDetail = input.MapTo<FolderDetail>();

           await _folderDetailRepository.DeleteAsync(@folderDetail.Id);
       }


    }
}
