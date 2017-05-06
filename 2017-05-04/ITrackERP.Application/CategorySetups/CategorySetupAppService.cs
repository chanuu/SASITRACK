using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.CategorySetups.DTOs;
using ITrackERP.ComlianceAndSafety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.CategorySetups
{
    public class CategorySetupAppService : ITrackERPAppServiceBase, ICategorySetupAppService
    {
        private readonly IRepository<CategorySetup, Guid> _categorySetupRepository;
        public CategorySetupAppService(IRepository<CategorySetup, Guid> categorySetupRepository)
        {
            _categorySetupRepository = categorySetupRepository;
        }

        public ListResultOutput<CategorySetupListDto> GetAll() 
        {
            var categorySetup = _categorySetupRepository.GetAll().ToList();

            return new ListResultOutput<CategorySetupListDto>(categorySetup.MapTo<List<CategorySetupListDto>>());
        }

        public ListResultOutput<CategorySetupListDto> GetCategoryItemsByLevelNo(CategoryTypeInputDto input)
        {
            var categoryitem = _categorySetupRepository
                .GetAll()
                .Where(e => e.Name == input.Name & e.LevelNo == input.LevelNo & e.Type == "Document")
                .ToList();

            return new ListResultOutput<CategorySetupListDto>(categoryitem.MapTo<List<CategorySetupListDto>>());
        }

        public CategorySetupDto GetDetailByName(CategoryNameInputDto input)
        {
            var categoryitem = _categorySetupRepository
                .GetAll()
                .Where(e => e.CategoryName == input.CategoryName & e.LevelNo == input.LevelNo & e.Type == "Document")
                .ToList().FirstOrDefault();

            return categoryitem.MapTo<CategorySetupDto>();

        }


        public CategorySetupDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @categorySetup = _categorySetupRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@categorySetup == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @categorySetup.MapTo<CategorySetupDto>();
        }

        public async Task Create(CreateCategorySetupDto input)
        {
            var @categorySetup = input.MapTo<CategorySetup>();
            @categorySetup = CategorySetup.Create(AbpSession.GetTenantId(), input.Type, input.Name, input.LevelNo, input.CategoryName, input.Remark);
            await _categorySetupRepository.InsertAsync(@categorySetup);

        }

        public async Task Update(EditCategorySetupDto input)
        {
            var @categorySetup = input.MapTo<CategorySetup>();
            @categorySetup.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _categorySetupRepository.UpdateAsync(@categorySetup);
        }
        public async Task Delete(DeleteCategorySetupDto input)
        {
            var @categorySetup = input.MapTo<CategorySetup>();

            await _categorySetupRepository.DeleteAsync(@categorySetup.Id);
        }

    }
}
