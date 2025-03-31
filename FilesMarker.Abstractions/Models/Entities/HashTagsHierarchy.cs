using System.ComponentModel.DataAnnotations.Schema;
using FilesMarker.Repository.Entities;

namespace FilesMarker.Abstractions.Models.Entities;

public class HashTagsHierarchy : BaseEntity
{
    [Column("name")]
    public required string Name { get; set; }
    
    public ICollection<HashTag> HashTags { get; } = [];
}
