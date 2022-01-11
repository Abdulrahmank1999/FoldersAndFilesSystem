using FoldersAndFiles.Models;

namespace FoldersAndFiles.Interfaces
{
    public interface IFilesRepository
    {
        public IEnumerable<Models.File> GetFiles();

        public void AddFile(Models.File file);

        public void RemoveFile(int id);

        public void EditFile(Models.File file, int id);

    }
}
