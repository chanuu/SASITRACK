using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITrackERP.CuttingRatios.Dto;
using ITRACK.Cutting;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using System.Data.Entity;
using Abp.UI;
using Abp.Runtime.Session;
using ITrackERP.Company;

namespace ITrackERP.CuttingRatios
{
    public class CuttingRatioAppService : ITrackERPAppServiceBase, ICuttingRatioAppService
    {
        private readonly IRepository<CuttingRatio, Guid> _cuttingRatioRepository;
        private readonly IRepository<CuttingMaster, Guid> _cuttingmasterRepository;
        public CuttingRatioAppService(IRepository<CuttingRatio, Guid> cuttingRatioRepository, IRepository<CuttingMaster, Guid> cuttingMasterRepository)
        {
            _cuttingRatioRepository = cuttingRatioRepository;
            _cuttingmasterRepository = cuttingMasterRepository;
        }

        public ListResultDto<CuttingRatioListDto> GetCuttingRatio()
        {
            var cuttingratio = _cuttingRatioRepository.GetAll()
                .Include(x => x.Style)
                .Include(x => x.CuttingRatioItem)

                .ToList();

            return new ListResultOutput<CuttingRatioListDto>(cuttingratio.MapTo<List<CuttingRatioListDto>>());
        }



       public async Task CreateItem(CreateCuttingRatioItemDto input)
        {
            var item = input.MapTo<CreateCuttingRatioItemDto>();
           

            var @header = _cuttingRatioRepository.Get(input.CuttingRatioId);

            var @Item = input.MapTo<CuttingRatioItem>();
            @Item = CuttingRatioItem.Create(input.Size,input.Lot);

            @header.CuttingRatioItem.Add(@Item);

            await CurrentUnitOfWork.SaveChangesAsync();
        }


        public async Task UpdateItem(EditCuttingRatioItemDto input)
        {
            var item = input.MapTo<EditCuttingRatioItemDto>();


            var @header = _cuttingRatioRepository.Get(input.CuttingRatioId);

            var @Item = input.MapTo<CuttingRatioItem>();
            @Item = CuttingRatioItem.Create(input.Size, input.Lot);

            @header.CuttingRatioItem.Add(@Item);

            await CurrentUnitOfWork.SaveChangesAsync();
        }


        public ListResultDto<CuttingRatioListDto> GetCuttingRatioByStyle(EntityRequestInput<Guid> input)
        {

            var header = _cuttingmasterRepository.Get(input.Id);
            var cuttingratio = _cuttingRatioRepository.GetAll()
                .Include(x => x.Style)
                .Where(x=>x.StyleId == header.StyleId)
                .Include(x => x.CuttingRatioItem)

                .ToList();

            return new ListResultOutput<CuttingRatioListDto>(cuttingratio.MapTo<List<CuttingRatioListDto>>());
        }

        public CuttingRatioDetailsDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @cuttingratio = _cuttingRatioRepository
               .GetAll()

               .Where(e => e.Id == input.Id)
               .Include(x=>x.CuttingRatioItem)
               .ToList().FirstOrDefault();

            if (@cuttingratio == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @cuttingratio.MapTo<CuttingRatioDetailsDto>();
        }



        public async Task Create(CreateCuttingRatioInputDto input)
        {
            var @ratio = input.MapTo<CuttingRatio>();
            @ratio = CuttingRatio.Create(AbpSession.GetTenantId(), input.StyleId, input.RatioNo, input.Color, "",
                0, 0, 0, "", "");

            int i = 0;
            await _cuttingRatioRepository.InsertAsync(@ratio);
        }

    }
}
