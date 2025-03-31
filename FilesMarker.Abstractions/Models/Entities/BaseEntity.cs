using System.ComponentModel.DataAnnotations.Schema;

namespace FilesMarker.Abstractions.Models.Entities;

public class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("created", TypeName = "timestamp(6)")]
    public DateTime CreatedDate { get; set; }
    
    [Column("modified", TypeName = "timestamp(6)")]
    public DateTime ModifiedDate { get; set; }
}