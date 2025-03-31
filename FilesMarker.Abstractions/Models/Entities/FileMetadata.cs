using System.ComponentModel.DataAnnotations.Schema;
using FilesMarker.Repository.Entities;

namespace FilesMarker.Abstractions.Models.Entities;

public class FileMetadata : BaseEntity
{
    [Column("file_path")]
    public required string FilePath { get; init; }
    
    public ICollection<HashTag> HashTags { get; } = [];
}
