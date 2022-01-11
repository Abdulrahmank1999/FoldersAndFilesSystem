using AutoMapper;
using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models.Dto;

namespace FoldersAndFiles.Services
{
    public class FileService:IFileService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        public FileService(IMapper mapper, IUnitOfWork UOW)
        {
            _mapper = mapper;
            _UOW = UOW;

        }

        public void AddFile(FileDto file)
        {
            
                Models.File result = _mapper.Map<Models.File>(file);

                _UOW.FilesRepository.AddFile(result);
                _UOW.Complete();
            

        }

        public void EditFile(FileDto file, int id)
        {
            Models.File result = _mapper.Map<FileDto,Models.File>(file);
            _UOW.FilesRepository.EditFile(result, id);
            _UOW.Complete();
        }

        public IEnumerable<FileDto> GetFiles()
        {
            IEnumerable<Models.File> files = _UOW.FilesRepository.GetFiles();

            IEnumerable<FileDto> LFDto = _mapper.Map<IEnumerable<Models.File>, IEnumerable<FileDto>>(files);

            return LFDto;


        }

        public void RemoveFile(int id)
        {
            _UOW.FilesRepository.RemoveFile(id);
            _UOW.Complete();
        }

    }
}
