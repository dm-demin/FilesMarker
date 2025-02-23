using System.ComponentModel.DataAnnotations.Schema;

namespace FilesMarker.Repository.Models;

public class HashTagsHierarchy : BaseEntity
{
    [Column("name")]
    public required string Name { get; set; }
    
    public ICollection<HashTag> HashTags { get; } = [];
}
