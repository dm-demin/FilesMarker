using FilesMarker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesMarker.Repository.Implementation;

public class HashTagsHierarchiesRepository(DbContext context) : BaseRepository<HashTagsHierarchy>(context)
{
    
}
