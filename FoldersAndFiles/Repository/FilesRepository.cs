using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models;

namespace FoldersAndFiles.Repository
{
    public class FilesRepository : IFilesRepository
    {

        private readonly FoldersFilesDbContext _DbContext;

        public FilesRepository(FoldersFilesDbContext DbContext)
        {
            _DbContext= DbContext;
        }
        public void AddFile(Models.File file)
        {
            _DbContext.Files.Add(file);
        }

        public IEnumerable<Models.File> GetFiles()
        {
           return _DbContext.Files.ToList();
        }

        void IFilesRepository.EditFile(Models.File file,int id)
        {
            Models.File FileEdited = _DbContext.Files.First(f => f.Id == id);
            FileEdited.Name = file.Name;
            FileEdited.FolderId = file.FolderId;

            _DbContext.Files.Update(FileEdited);
        }

        void IFilesRepository.RemoveFile(int id)
        {
            Models.File Result = _DbContext.Files.First(f => f.Id ==id);
           
                _DbContext.Files.Remove(Result);
        }
    }
}
