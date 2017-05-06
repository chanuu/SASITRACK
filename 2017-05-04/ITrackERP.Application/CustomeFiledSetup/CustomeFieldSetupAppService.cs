using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using ITrackERP.CustomeFiledSetups.Dto;
using ITrackERP.CutPlan.Dto;
using ITrackERP.Master;
using ITrackERP.CustomeFiledSetup.Dto;

namespace ITrackERP.CustomeFiledSetups
{
    public class CustomeFieldSetupAppService : ITrackERPAppServiceBase, ICustomeFieldSetupAppService
    {
        private readonly IRepository<Master.CustomeFiledSetup, Guid> _customefieldsetupRepository;

        public CustomeFieldSetupAppService(IRepository<Master.CustomeFiledSetup, Guid> customefieldsetupRepository)
        {
            _customefieldsetupRepository = customefieldsetupRepository;
        }

        public ListResultOutput<CustomeFieldSetupListDto> GetCustomeFieldSetup()
        {
            var customefieldsetups = _customefieldsetupRepository.GetAll().ToList();

            return new ListResultOutput<CustomeFieldSetupListDto>(customefieldsetups.MapTo<List<CustomeFieldSetupListDto>>());
        }

        public CustomeFieldSetupDetailDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @customefieldsetup = _customefieldsetupRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();
            if (@customefieldsetup == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @customefieldsetup.MapTo<CustomeFieldSetupDetailDto>();
        }

        public CustomeFieldSetupDetailDto GetDetailByName(CustomeFieldItemTypeInputDto input)
        {
            var @customefieldsetup = _customefieldsetupRepository
                .GetAll()
                .Where(e => e.ItemType == input.ItemType)
                .ToList().FirstOrDefault();
            
            return @customefieldsetup.MapTo<CustomeFieldSetupDetailDto>();
        }

        public async Task Create(CreateCustomeFieldSetupInputDto input)
        {
            var @customefieldsetup = input.MapTo<Master.CustomeFiledSetup>();

            @customefieldsetup = Master.CustomeFiledSetup.Create(AbpSession.GetTenantId(), input.CustomFieldNo,
                input.ItemType, input.CustomeField1, input.CustomeField2, input.CustomeField3, input.CustomeField4,
                input.CustomeField5, input.CustomeField6, input.CodeLength, input.ItemCodeGenerate);
           
            await _customefieldsetupRepository.InsertAsync(@customefieldsetup);
        }

        public async Task Update(EditCustomeFieldSetupDto input)
        {
            var @order = input.MapTo<Master.CustomeFiledSetup>();
            @order.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _customefieldsetupRepository.UpdateAsync(@order);
        }

        public async Task Delete(DeleteCustomFieldSetupDto input)
        {
            var @customfieldsetup = input.MapTo<Master.CustomeFiledSetup>();

            await _customefieldsetupRepository.DeleteAsync(@customfieldsetup.Id);
        }




    }
}
