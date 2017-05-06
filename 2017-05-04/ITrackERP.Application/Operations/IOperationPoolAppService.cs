using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Operations.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Operations
{
    public interface IOperationPoolAppService : IApplicationService
    {
        ListResultOutput<OperationPoolListDto> GetOperations();

        OperationPoolDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateOperationPoolDto input);

        Task Update(EditOperationPoolDto input);

        Task DeleteOperation(DeleteOperationPoolDto input);
    }
}
