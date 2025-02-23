using FileMarker.Abstractions;
using FilesMarker.Repository.Exceptions;
using FilesMarker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesMarker.Repository.Implementation;

public class BaseRepository<T>(DbContext context) : IRepository<T>
    where T : BaseEntity
{
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await SelectEntityByIdAsync(id);
    }

    public IEnumerable<T> Find()
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync (T entity)
    {
        entity.CreatedDate = DateTime.Now;

        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return await SelectEntityByIdAsync(entity.Id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        entity.ModifiedDate = DateTime.Now;

        context.Update(entity);
        await context.SaveChangesAsync();

        return await SelectEntityByIdAsync(entity.Id);
    }

    public void Delete(Guid id)
    {
        context.Remove(id);
    }

    private async Task<T> SelectEntityByIdAsync(Guid id)
    {
        context.ChangeTracker.AutoDetectChangesEnabled = false;
        return await context.FindAsync<T>(id) ?? throw new EntityNotFoundException();
    }
}