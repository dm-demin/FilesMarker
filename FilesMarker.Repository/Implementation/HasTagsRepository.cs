using FilesMarker.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilesMarker.Repository.Implementation;

public class HasTagsRepository(DbContext context) : BaseRepository<HashTag>(context)
{
    
}
