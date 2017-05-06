using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.Files.DTOs;
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
using ITrackERP.Files1.DTOs;

namespace ITrackERP.Files
{
    public class FileAppService: ITrackERPAppServiceBase, IFileAppService
    {
        private readonly IRepository<ComlianceAndSafety.Files, Guid> _fileRepository;
        public FileAppService(IRepository<ComlianceAndSafety.Files, Guid> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public ListResultOutput<FileListDto> GetAll() 
        {
            var file = _fileRepository.GetAll().ToList();

            return new ListResultOutput<FileListDto>(file.MapTo<List<FileListDto>>());
        }
        public ListResultOutput<FileListDto> GetAllByFileType(FileTypeInputDto input)
        {
            var file = _fileRepository.GetAll()
                .Where(x => x.CustomeFiledSetupId == input.CustomeFiledSetupId)
                .ToList();

            return new ListResultOutput<FileListDto>(file.MapTo<List<FileListDto>>());
        }


        public FileDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @file = _fileRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@file == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @file.MapTo<FileDto>();
        }

        public async Task Create(CreateFileDto input)
        {
            var @file = input.MapTo<ComlianceAndSafety.Files>();
            @file = ComlianceAndSafety.Files.Create(AbpSession.GetTenantId(), input.CustomeFiledSetupId,  input.Type, input.CustomField1, input.CustomField2, input.CustomField3, input.CustomField4, input.CustomField5, input.CustomField6, input.Category1, input.Category2, input.Category3, input.Category4, input.Category5, input.Path);
            await _fileRepository.InsertAsync(@file);

        }

        public async Task Update(EditFileDto input)
        {
            var @file = input.MapTo<ComlianceAndSafety.Files>();
            @file.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _fileRepository.UpdateAsync(@file);
        }
        public async Task Delete(DeleteFileDto input)
        {
            var @file = input.MapTo<ComlianceAndSafety.Files>();

            await _fileRepository.DeleteAsync(@file.Id);
        }

    }
}

