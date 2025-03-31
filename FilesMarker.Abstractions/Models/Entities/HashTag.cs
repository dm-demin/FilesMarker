using System.ComponentModel.DataAnnotations.Schema;
using FilesMarker.Abstractions.Models.Entities;

namespace FilesMarker.Repository.Entities;

public class HashTag : BaseEntity
{
    [Column("name")]
    public required string Name { get; set; }
    
    [Column("parent_id")]
    public Guid? ParentId { get; set; }
    
    [Column("hierarchy_id")]
    public Guid? HierarchyId { get; set; }

    public ICollection<FileMetadata> Files { get; } = [];
    public HashTagsHierarchy? Hierarchy { get; set; }
}
