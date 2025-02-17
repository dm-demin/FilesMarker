using Microsoft.EntityFrameworkCore;
using FilesMarker.Repository.Models;

namespace FilesMarker.Repository.Contexts
{
    public class FilesMetadataContext(DbContextOptions<FilesMetadataContext> options) : DbContext(options)
    {
        public DbSet<FileMetadata> Files { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<HashTagsHierarchy> HashTagsHierarchies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileMetadata>().ToTable("files")
                .HasMany(x => x.HashTags)
                .WithMany(x => x.Files)
                .UsingEntity("files_hashtags",
                l => l.HasOne(typeof(FileMetadata)).WithMany().HasForeignKey("file_id").HasPrincipalKey(nameof(FileMetadata.Id)),
                r => r.HasOne(typeof(HashTag)).WithMany().HasForeignKey("hashtag_id").HasPrincipalKey(nameof(HashTag.Id)),
                j => j.HasKey("file_id", "hashtag_id"));
            
            modelBuilder.Entity<HashTag>().ToTable("hashtags")
                .HasMany(x => x.Files)
                .WithMany(x => x.HashTags)
                .UsingEntity("files_hashtags",
                    l => l.HasOne(typeof(FileMetadata)).WithMany().HasForeignKey("file_id").HasPrincipalKey(nameof(FileMetadata.Id)),
                    r => r.HasOne(typeof(HashTag)).WithMany().HasForeignKey("hashtag_id").HasPrincipalKey(nameof(HashTag.Id)),
                    j => j.HasKey("file_id", "hashtag_id"));
            
            modelBuilder.Entity<HashTagsHierarchy>().ToTable("hashtags_hierarchies")
                .HasMany(x => x.HashTags)
                .WithOne(x => x.Hierarchy)
                .HasForeignKey(x => x.HierarchyId)
                .IsRequired(false)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
