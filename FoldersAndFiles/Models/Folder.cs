using System.ComponentModel.DataAnnotations;

namespace FoldersAndFiles.Models
{
    public class Folder
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ContainerId { get; set; }
        public Folder? Container { get; set; }

        

        public ICollection<File> Files { get; set; }

        public Folder()
        {
            
            Files=new List<File>();
            ContainerId = null;
        }
    }
}
