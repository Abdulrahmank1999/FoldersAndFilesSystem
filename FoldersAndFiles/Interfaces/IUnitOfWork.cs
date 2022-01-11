namespace FoldersAndFiles.Interfaces
{
    public interface IUnitOfWork
    {
        public IFilesRepository FilesRepository { get; }
        public IFoldersRepository FoldersRepository { get; }
        public void Complete();
    }
}
