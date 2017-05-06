using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ITrackERP.Company;
using ITrackERP.CuttingMasters.Dto;
using ITrackERP.CuttingRatios.Dto;
using ITRACK.Cutting;
using Abp.Linq.Extensions;
using ITrackERP.IssueNoteItems.DTOs;
using System.Diagnostics;
using ITRACK.Costing;

namespace ITrackERP.CuttingMasters
{
   public class CuttingMasterAppService : ITrackERPAppServiceBase, ICuttingMasterAppService
   {
       private readonly IRepository<CuttingMaster, Guid> _cuttingmasterRepository;
        private readonly IRepository<CuttingRatio, Guid> _ratioRepository;
       private readonly IRepository<CuttingItem, Guid> _cuttingitemRepository;
        private readonly IRepository<WorkOrderRatio, Guid> _workorderRatioRepository;

        public CuttingMasterAppService(IRepository<CuttingMaster, Guid> cuttingmasterRepository,IRepository<CuttingItem, Guid> cuttingitemRepository, IRepository<CuttingRatio, Guid> ratioRepository, IRepository<WorkOrderRatio, Guid> workorderRatioRepository)
           
       {
           _cuttingmasterRepository = cuttingmasterRepository;
           _cuttingitemRepository = cuttingitemRepository;
            _ratioRepository = ratioRepository;
            _workorderRatioRepository = workorderRatioRepository;
       }


        public ListResultDto<CuttingMasterDto> GetCuttingMaster()
        {
            var cuttingmaster = _cuttingmasterRepository.GetAll()
                .Include(x => x.CuttingItems)
                .Include(x=>x.Style)

                .OrderBy(x => x.CreationTime);


            return new ListResultDto<CuttingMasterDto>(cuttingmaster.ProjectTo<CuttingMasterDto>().ToList());
            //return cuttingmaster.ProjectTo<CuttingMasterDto>().ToList();
           // return new ListResultOutput<CuttingMasterDto>(cuttingmaster.MapTo<List<CuttingMasterDto>>());
        }



        public ListResultDto<CuttingMasterDto> GetActiveCuttingMaster()
        {
            var cuttingmaster = _cuttingmasterRepository.GetAll()
                .Include(x => x.CuttingItems)
                .Include(x => x.Style)
                 .WhereIf(true, Y => Y.isCuttingFinised == false && Y.isCuttingStarted == true)
                .OrderBy(x => x.CreationTime);


            return new ListResultDto<CuttingMasterDto>(cuttingmaster.ProjectTo<CuttingMasterDto>().ToList());
            //return cuttingmaster.ProjectTo<CuttingMasterDto>().ToList();
            // return new ListResultOutput<CuttingMasterDto>(cuttingmaster.MapTo<List<CuttingMasterDto>>());
        }


        public ListResultDto<CuttingItemListDto> GetCuttingItems(GetCuttingItemInput input )
        {
            var @cuttingmaster = _cuttingitemRepository.GetAll()
                .Include(x => x.CuttingMaster)
                .WhereIf(true, Y => Y.Date >= input.From && Y.Date <= input.To)
                .OrderBy(x => x.CreationTime);




              return new ListResultDto<CuttingItemListDto>(cuttingmaster.ProjectTo<CuttingItemListDto>().ToList());
          
        }

        public ListResultDto<CuttingItemListDto> GetCuttingItemsGroupByStyle(GetCuttingItemInput input)
        {
            var @cuttingmaster = _cuttingitemRepository.GetAll()

                .Include(x => new { x.CuttingMaster })

                .GroupBy(x => new { x.CuttingMaster.StyleNo, x.Date })

                .WhereIf(true, Y => Y.Key.Date >= input.From && Y.Key.Date <= input.To)

                .Select(x => new { StyleNo = x.Key.StyleNo, Date = x.Key.Date, Pcs = x.Sum(c => c.NoOfItem) });
               




            return new ListResultDto<CuttingItemListDto>(cuttingmaster.ProjectTo<CuttingItemListDto>().ToList());
            // return @cuttingmaster.MapTo<CuttingItemDto>();


            //  return new ListResultOutput<CuttingItemListDto>(cuttingmaster.MapTo<List<CuttingItemListDto>>());
        }




        public cuttingItemDetailsDto GetItemDetail(EntityRequestInput<Guid> input)
        {
            var @issueNoteItem = _cuttingitemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @issueNoteItem.MapTo<cuttingItemDetailsDto>();
        }

        public ListResultDto<CuttingItemListDto> GetCuttingItemByID(EntityRequestInput<Guid> input)
        {
            var @cuttingmaster = _cuttingitemRepository.GetAll()
              
                .WhereIf(true, Y => Y.CuttingMasterId == input.Id)
                .OrderBy(x => x.CreationTime);




            return new ListResultDto<CuttingItemListDto>(cuttingmaster.ProjectTo<CuttingItemListDto>().ToList());

        }




        int getDalyCut(string _styleNo, GetCuttingItemInput input) {

            var item = _cuttingitemRepository.GetAll()
                     .WhereIf(true, X => X.CuttingMaster.StyleNo == _styleNo && X.Date ==input.From )
                     .ToList();
            var sum = item
                      .GroupBy(x => x.CuttingMasterId)
                      .Select(x => x.Sum(y => y.NoOfItem));

            return sum.FirstOrDefault();
        }

        int getCutCumm(string _styleNo)
        {

            var item = _cuttingitemRepository.GetAll()
                     .WhereIf(true, X => X.CuttingMaster.StyleNo == _styleNo)
                     .ToList();
            var sum = item
                      .GroupBy(x => x.CuttingMasterId)
                      .Select(x => x.Sum(y => y.NoOfItem));

            return sum.FirstOrDefault();
        }

        public  ListResultDto<CuttingSummaryDto> GetCuttingSummary(GetCuttingItemInput input)
        {
            var @cuttingmaster = _cuttingitemRepository.GetAll()

             .WhereIf(true, Y => Y.Date == input.From)
              .Select(m => new { m.CuttingMaster.StyleNo})
              .Distinct()
             .ToList();
            List<CuttingSummaryDto> list = new List<CuttingSummaryDto>();
            foreach (var row in @cuttingmaster)
            {
               
                int orderQty = 0;
                var orders = _workorderRatioRepository.GetAll()

                             .WhereIf(true, X => X.WorkOrderHeader.StyleNo == row.StyleNo)

                             .ToList();
                int sum = 0;
                foreach(var or in orders)
                {
                    sum = or.Quantity + sum;
                }

                orderQty = sum;
               
                list.Add(new CuttingSummaryDto {Date=input.From, StyleNo = row.StyleNo, OrderQty = orderQty ,ActualQty = getDalyCut(row.StyleNo,input),Cumm = getCutCumm(row.StyleNo),Balance = getCutCumm(row.StyleNo)- orderQty });
               
            }

            
           
            return new ListResultOutput<CuttingSummaryDto>(list.MapTo<List<CuttingSummaryDto>>());

        }

        public async Task DeleteItem(createCuttingItemDto input )
        {
            var item = _cuttingitemRepository.Get(input.Id);
            if (item == null)
            {
                throw new UserFriendlyException("Could not found the Item, maybe it's deleted.");
            }
            await _cuttingitemRepository.DeleteAsync(item);
        }

        public async Task UpdateItem(createCuttingItemDto input)
        {
            var @Item = input.MapTo<CuttingItem>();

            var cutItem = _cuttingitemRepository.Get(input.Id);
            cutItem.Date = input.Date;
            cutItem.LayerNo = input.LayerNo;
            cutItem.CutNo = input.CutNo;
            cutItem.Color = input.Color;
            cutItem.Size = input.Size;
            cutItem.NoOfItem = input.NoOfItem;
            cutItem.NoOfPlys = input.NoOfPlys;
            cutItem.PoNo = input.PoNo;

            await _cuttingitemRepository.UpdateAsync(cutItem);
        }


        public CuttingMasterDto GetDetail(EntityRequestInput<Guid> input)
       {
           var @cuttingmaster = _cuttingmasterRepository
               .GetAll()
               .Include(x => x.CuttingItems)
                .OrderByDescending(x => x.CreationTime) 


               .Where(e => e.Id == input.Id )
               .ToList().FirstOrDefault();

            if (@cuttingmaster == null)
            {
                throw new UserFriendlyException("Could not found the Item, maybe it's deleted.");
            }
            return @cuttingmaster.MapTo<CuttingMasterDto>();


        }

        /// <summary>
        /// inline opration 
        /// </summary>
        /// <param name="_styleNo"></param>
        /// <returns></returns>

        public string getCutNo(string _styleNo)
        {

          string _cutNo = "";
          var row =  _cuttingitemRepository.GetAll()
                  .OrderByDescending(x => x.CreationTime)
                  .Where(e=>e.CuttingMaster.StyleNo == _styleNo)
           
                  .ToList().FirstOrDefault();

            if ( row != null)
            {
                int cutNo = Convert.ToInt16(row.CutNo)+1;
                _cutNo = cutNo.ToString().PadLeft(4, '0');
            }
            else
            {
                _cutNo = "0001";
            }

            return _cutNo;
        }

       

        public async Task Create(CreateCuttingMasterDto input)
       {
            var @cuttingmaster = input.MapTo<CuttingMaster>();
           @cuttingmaster = CuttingMaster.Create(AbpSession.GetTenantId(),input.CuttingMasterNo, input.ItemType, input.Remark, input.Status, input.StyleId,input.StyleNo);
            int i = 0;
            await _cuttingmasterRepository.InsertAsync(@cuttingmaster);
        }

        public async Task Update(EditCuttingMasterDto input)
        {
            var @cuttingmaster= input.MapTo<CuttingMaster>();
            @cuttingmaster.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _cuttingmasterRepository.UpdateAsync(@cuttingmaster);
        }



        public async Task Finalized(EntityRequestInput<Guid> input)
        {
           

            var cuttingHeader = _cuttingmasterRepository.Get(input.Id);


            if (cuttingHeader.isCuttingStarted == true || cuttingHeader.isCuttingFinised == false)
            {


                cuttingHeader.isCuttingFinised = true;
                cuttingHeader.CuttingFinishedDate = DateTime.Now;
                cuttingHeader.TenantId = AbpSession.GetTenantId();
                cuttingHeader.Status = "Completed";
               
                await _cuttingmasterRepository.UpdateAsync(cuttingHeader);
            }

          
        }

        public async Task Update(EditCuttingItemDto input)
        {
            var @cuttingmaster = input.MapTo<CuttingItem>();
            @cuttingmaster.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _cuttingitemRepository.UpdateAsync(@cuttingmaster);
        }

        public async Task CreateItem(CreateCuttingItemDto input)
        {
            var cuttingHeader = _cuttingmasterRepository.Get(input.CuttingMasterId);

            if (cuttingHeader.isCuttingStarted == false)
            {
                cuttingHeader.isCuttingStarted = true;
                cuttingHeader.CuttingStartedDate = DateTime.Now;
            }

            var cuttingRatio = _ratioRepository.Get(input.CuttingRatioId);

           

            var @cuttingMaster = input.MapTo<CuttingItem>();

       

            foreach (var item in cuttingRatio.CuttingRatioItem)
            {
                @cuttingMaster.CutNo = getCutNo(cuttingHeader.StyleNo); 

                cuttingMaster.Date = DateTime.Now;

                @cuttingMaster.TenantId = AbpSession.GetTenantId();

                @cuttingMaster.Size = item.Size;

                @cuttingMaster.Color = cuttingRatio.Color;

                int noOfItem = item.Lot * @cuttingMaster.NoOfItem;

                int noofPlys = @cuttingMaster.NoOfItem;

                var   @citem = CuttingItem.Create(@cuttingMaster.CutNo, input.PoNo, input.LayerNo, input.FabricType, DateTime.Now, cuttingRatio.Color, item.Size, input.Length, input.LotNo, noOfItem, noofPlys, input.IsTagGenarated, input.IsIssued, input.TagPrintedTime);

                cuttingHeader.CuttingItems.Add(@citem);
            }

          

          

            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }

}
