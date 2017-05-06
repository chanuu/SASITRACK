using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.CategorySetups.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CategorySetups
{
    public interface ICategorySetupAppService : IApplicationService
    {
        ListResultOutput<CategorySetupListDto> GetAll();

        ListResultOutput<CategorySetupListDto> GetCategoryItemsByLevelNo(CategoryTypeInputDto input);

        CategorySetupDto GetDetailByName(CategoryNameInputDto input);

        CategorySetupDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateCategorySetupDto input);

        Task Update(EditCategorySetupDto input);

        Task Delete(DeleteCategorySetupDto input);
    }
}
