using System.ComponentModel.DataAnnotations.Schema;

namespace FilesMarker.Repository.Models;

public class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("created")]
    public DateTime CreatedDate { get; set; }
    
    [Column("modified")]
    public DateTime ModifiedDate { get; set; }
}