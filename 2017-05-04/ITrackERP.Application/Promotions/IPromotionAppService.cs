using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Promotions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Promotions
{
    public interface IPromotionAppService : IApplicationService
    {
        PromotionDto GetPromotionByID(EntityRequestInput<Guid> input);
        Task UpdatePromotion(EditPromotionDto input);


        Task CreatePromotion(CreatePromotionDto input);

        Task DeletePromotion(DeletePromotionDto input);


    }
}
