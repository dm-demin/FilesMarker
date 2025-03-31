namespace FilesMarker.Abstractions.Interfaces;

public interface IRepository<T>
{
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> GetByIdAsync(Guid id);
    
    public IEnumerable<T> Find();
    public void Delete(Guid id);
}
