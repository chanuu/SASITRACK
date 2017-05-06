using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.FolderDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FolderDetails
{
    public interface IFolderDetailAppService : IApplicationService
    {
        FolderDetailDto GetFolderDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateFolderDetail(EditFolderDetailDto input);

        Task CreateFolderDetail(CreateFolderDetailDto input);

        Task DeleteFolderDetail(DeleteFolderDetailDto input);


    }

}
