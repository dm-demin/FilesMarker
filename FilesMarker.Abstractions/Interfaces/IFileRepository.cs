using FilesMarker.Abstractions.Models.Entities;
using FilesMarker.Repository.Entities;

namespace FilesMarker.Abstractions.Interfaces;

public interface IFileRepository : IRepository<FileMetadata>
{
    Task<FileMetadata> GetByPathAsync(string path);
}