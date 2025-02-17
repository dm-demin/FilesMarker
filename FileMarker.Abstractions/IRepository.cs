namespace FileMarker.Abstractions;

public interface IRepository<T>
{
    public T Create(T entity);
    public T Update(T entity);
    public void Delete(string id);
    
    public T Get(string id);
    public IEnumerable<T> GetAll();
}
