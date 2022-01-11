using FoldersAndFiles.Models.Dto;

namespace FoldersAndFiles.Interfaces
{
    public interface IFolderService
    {
        public IEnumerable<FolderDto> GetFolders();

        public FolderDto AddFolder(FolderDto folder);

        public void RemoveFolder(int id);

        public void EditFolder(FolderDto folder, int id);
    }
}
