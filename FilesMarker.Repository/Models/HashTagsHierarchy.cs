using System.ComponentModel.DataAnnotations.Schema;

namespace FilesMarker.Repository.Models;

public record HashTagsHierarchy
{
    [Column("id")]
    public Guid Id { get; init; }
    
    [Column("name")]
    public required string Name { get; init; }
    
    public ICollection<HashTag> HashTags { get; } = [];
}
