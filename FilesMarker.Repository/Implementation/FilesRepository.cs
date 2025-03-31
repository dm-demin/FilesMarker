using FilesMarker.Abstractions.Interfaces;
using FilesMarker.Abstractions.Models.Entities;
using FilesMarker.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FilesMarker.Repository.Implementation;

public class FilesRepository(FilesMetadataContext context) : BaseRepository<FileMetadata>(context), IFileRepository
{
    public async Task<FileMetadata> GetByPathAsync(string path)
    {
        FileMetadata? result = await context.Files.Where(f => f.FilePath == path).FirstOrDefaultAsync();

        if (result == null)
        {
            throw new FileNotFoundException();
        }
        
        return result;
    }
}
