using System.ComponentModel.DataAnnotations.Schema;

namespace FilesMarker.Repository.Models;

public class FileMetadata : BaseEntity
{
    [Column("id")]
    public Guid Id { get; init; }
    
    [Column("file_path")]
    public required string FilePath { get; init; }
    
    public ICollection<HashTag> HashTags { get; } = [];
}
