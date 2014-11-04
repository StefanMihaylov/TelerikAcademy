namespace FileUpload.Model
{
    using FileUpload.Migrations;
    using System.Data.Entity;

    public class FileDbContext : DbContext
    {
        public FileDbContext()
            : base("UploadFilesDb")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<FileDbContext, Configuration>());
        }

        public DbSet<File> Files { get; set; }
    }
}