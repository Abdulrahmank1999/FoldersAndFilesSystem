using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models;
using FoldersAndFiles.Models.Dto;
using FoldersAndFiles.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoldersAndFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderService _Folders;

        public FoldersController(IFolderService folders)
        {
            _Folders = folders;

        }
        [HttpGet]
        public IEnumerable<FolderDto> GetFolders()
        {
            return _Folders.GetFolders();
        }

        [HttpPost]
        public FolderDto AddFolder(FolderDto folder)
        {
            return _Folders.AddFolder(folder);
        }

        [HttpPut("updatefolder")]
        public void Update(FolderDto folder, int id)
        {
            _Folders.EditFolder(folder, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _Folders.RemoveFolder(id);
        }
    }
}
