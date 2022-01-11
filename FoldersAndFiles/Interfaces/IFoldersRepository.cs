using FoldersAndFiles.Models;

namespace FoldersAndFiles.Interfaces
{
    public interface IFoldersRepository
    {
        public IEnumerable<Folder> GetFolders();

        public void AddFolder(Folder folder);

        public void RemoveFolder(int id);

        public void EditFolder(Folder folder, int id);

        public void RemoveCascade(int id);
    }
}
