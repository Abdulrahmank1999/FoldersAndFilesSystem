using AutoMapper;
using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models;
using FoldersAndFiles.Models.Dto;
using FoldersAndFiles.Repository;

namespace FoldersAndFiles.Services
{
    public class FolderService : IFolderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        public FolderService(IMapper mapper, IUnitOfWork UOW)
        {
            _mapper=mapper;
            _UOW = UOW;

        }
        public FolderDto AddFolder(FolderDto folder)
        {

            
                Folder result = _mapper.Map<Folder>(folder);

                _UOW.FoldersRepository.AddFolder(result);
                _UOW.Complete();
            return folder;
           
        }

        public void EditFolder(FolderDto folder, int id)
        {
            Folder result = _mapper.Map<FolderDto,Folder>(folder);
            _UOW.FoldersRepository.EditFolder(result, id);
            _UOW.Complete();
        }

        public IEnumerable<FolderDto> GetFolders()
        {
            IEnumerable<Folder> folders = _UOW.FoldersRepository.GetFolders();

            IEnumerable<FolderDto> LFDto = _mapper.Map<IEnumerable<Folder>, IEnumerable<FolderDto>>(folders);

            return LFDto;

        }

        public void RemoveFolder(int id)
        {
            _UOW.FoldersRepository.RemoveFolder(id);
            _UOW.Complete();
        }
    }
}
