using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Elements.DTOs;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace ITrackERP.Elements
{
    public class ElementAppService: ITrackERPAppServiceBase, IElementAppService
    {
        private readonly IRepository<Element, Guid> _elementRepository;

        public ElementAppService(IRepository<Element, Guid> elementRepository)
        {
            _elementRepository = elementRepository;
        }

        public ListResultOutput<ElementDto> GetElements() 
        {
            var elements = _elementRepository.GetAll().ToList();

            return new ListResultOutput<ElementDto>(elements.MapTo<List<ElementDto>>());
        }

        public ElementDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @element = _elementRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@element == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @element.MapTo<ElementDto>();
        }

       public ListResultOutput<ElementDto> GetDetailByCategory(CategoryInputDto input)
        {
            var @elements = _elementRepository
                .GetAll()
                .Where(e => e.Category == input.Category)
                .ToList();

            return new ListResultOutput<ElementDto>(@elements.MapTo<List<ElementDto>>());
        }
        
       
        public async Task Create(CreateElementDto input)
        {
            var @element = input.MapTo<Element>();
            @element = Element.Create(AbpSession.GetTenantId(), input.Name, input.Length, input.Width, input.Category, input.Path);
            await _elementRepository.InsertAsync(@element);

        }

        public async Task Update(EditElementDto input)
        {
            var @element = input.MapTo<Element>();
            @element.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _elementRepository.UpdateAsync(@element);
        }
        public async Task Delete(DeleteElementDto input)
        {
            var @element = input.MapTo<Element>();

            await _elementRepository.DeleteAsync(@element.Id);
        }

    }
}

