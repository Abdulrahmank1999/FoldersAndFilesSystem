using FoldersAndFiles.Models.Dto;

namespace FoldersAndFiles.Interfaces
{
    public interface IFileService
    {
        public void RemoveFile(int id);

        public IEnumerable<FileDto> GetFiles();

        public void EditFile(FileDto file, int id);

        public void AddFile(FileDto file);
    }
}
