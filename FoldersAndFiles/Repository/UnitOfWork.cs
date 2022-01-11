using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models;

namespace FoldersAndFiles.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
       public IFoldersRepository FoldersRepository { get; }

        public IFilesRepository FilesRepository { get; }

        private readonly FoldersFilesDbContext _DbContext;
        public UnitOfWork(FoldersFilesDbContext DbContext)
        {
            _DbContext=DbContext;
            FoldersRepository = new FoldersRepository(DbContext);
            FilesRepository= new FilesRepository(DbContext);
        }

        

        public void Complete()
        {
            _DbContext.SaveChanges();
        }
    }
}
