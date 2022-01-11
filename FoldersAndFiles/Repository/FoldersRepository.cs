using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models;

namespace FoldersAndFiles.Repository
{
    public class FoldersRepository : IFoldersRepository
    {
        private readonly FoldersFilesDbContext _DbContext;

        public FoldersRepository(FoldersFilesDbContext DbContext)
        {
            _DbContext= DbContext;
        }
        

        public void AddFolder(Folder folder)
        {
            _DbContext.Folders.Add(folder);
        }

        public IEnumerable<Folder> GetFolders()
        {
            return _DbContext.Folders.ToList();
        }

        void IFoldersRepository.EditFolder(Folder folder,int id)
        {
            Models.Folder FolderEdited = _DbContext.Folders.First(f => f.Id == id);
            FolderEdited.Name = folder.Name;
            FolderEdited.ContainerId = folder.ContainerId;

            _DbContext.Folders.Update(FolderEdited);
        }

        void IFoldersRepository.RemoveFolder(int id)
        {
            RemoveCascade(id);


        }

        public void RemoveCascade(int id)
        {
            IEnumerable<Folder> results = _DbContext.Folders.Where(f => f.ContainerId == id);
            List<int?> ContainerIds = results.Select(l => l.ContainerId).ToList();

            foreach (Folder folder in results)
            {
                if (!ContainerIds.Contains(folder.Id))
                    _DbContext.Folders.Remove(folder);
                else
                    RemoveCascade(folder.Id);


            }
            Folder result = _DbContext.Folders.Single(f => f.Id == id);


            _DbContext.Folders.Remove(result);
        }
    }
}
