using FoldersAndFiles.Interfaces;
using FoldersAndFiles.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FoldersAndFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _Files;
        public FilesController(IFileService files)
        {
            _Files = files;
            
        }
        [HttpGet]
        public IEnumerable<FileDto> Get()
        {
            return _Files.GetFiles();
        }

        [HttpPost]
        public void Add(FileDto file)
        {
             _Files.AddFile(file);
             
        }

        [HttpPut]
        public void Update(FileDto file,int id)
        {
            _Files.EditFile(file,id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _Files.RemoveFile(id);
        }
    }
}
