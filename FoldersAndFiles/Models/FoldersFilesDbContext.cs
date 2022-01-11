using Microsoft.EntityFrameworkCore;

namespace FoldersAndFiles.Models
{
    public class FoldersFilesDbContext:DbContext
    {
        public DbSet<Folder> Folders { get; set; }

        public DbSet<File> Files { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=FoldersFiles;trusted_connection=true;");

            


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Folder>().HasMany(f => f.Files)
          .WithOne(c => c.Folder)
           .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
