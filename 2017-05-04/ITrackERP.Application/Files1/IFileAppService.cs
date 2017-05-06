using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Files.DTOs;
using ITrackERP.Files1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Files
{
    public interface IFileAppService : IApplicationService
    {
        ListResultOutput<FileListDto> GetAll();

        ListResultOutput<FileListDto> GetAllByFileType(FileTypeInputDto input);
        FileDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateFileDto input);

        Task Update(EditFileDto input);

        Task Delete(DeleteFileDto input);
    }
}
