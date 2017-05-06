using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using ITRACK.Costing;
using ITrackERP.Orders.Dto;
using ITrackERP.Company;
using ITrackERP.CuttingMasters.Dto;
using ITrackERP.EstimateConsumption.Dto;
using ITRACK.Cutting;

namespace ITrackERP
{
    [DependsOn(typeof(ITrackERPCoreModule), typeof(AbpAutoMapperModule))]
    public class ITrackERPApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
                //   mapper.CreateMap<WorkOrderHeader, EditWorkOrderDto>()
                //  .ForMember(dto => dto.Style, conf => conf.MapFrom(ol => ol.Style));

                mapper.CreateMap<CuttingMaster, CuttingMasterDto>()
       .ForMember(dto => dto.Style, conf => conf.MapFrom(ol => ol.Style.StyleNo));

                mapper.CreateMap<CuttingItem, CuttingItemListDto>()
                .ForMember(dto => dto.StyleId, conf => conf.MapFrom(ol => ol.CuttingMaster.StyleId));

                mapper.CreateMap<CuttingItem, CuttingItemListDto>()
            .ForMember(dto => dto.StyleNo, conf => conf.MapFrom(ol => ol.CuttingMaster.StyleNo));

                mapper.CreateMap<EstimateConsumptione, EstimateConsumptionListDto>()
            .ForMember(dto => dto.StyleNo, conf => conf.MapFrom(ol => ol.Style.StyleNo));

            });

          



        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
