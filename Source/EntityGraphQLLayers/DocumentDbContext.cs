using EntityGraphQLLayers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityGraphQLLayers
{
    public class DocumentDbContext : DbContext
    {
        public DocumentDbContext(DbContextOptions<DocumentDbContext> opts) : base(opts)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "projects.db");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .UseSqlite($"Data Source={dbPath}");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
    }
}
