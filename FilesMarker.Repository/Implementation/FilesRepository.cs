using FilesMarker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesMarker.Repository.Implementation;

public class FilesRepository(DbContext context) : BaseRepository<FileMetadata>(context)
{
    
}
