using System.ComponentModel.DataAnnotations;

namespace FoldersAndFiles.Models
{
    public class File
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public Folder Folder { get; set; }
        public int? FolderId { get; set; }

    }
}
