namespace DataProvider.Interfaces;

public interface IRepository<T>
{
    public T? GetById(string id);
    public T? GetByName(string name);
    public IEnumerable<T?> GetAllByName(string name);
    public IEnumerable<T?> GetAll();

    public void Delete(T entity);
    public void Update(T entity);
    public void Save(T entity);
    public void SaveOrUpdate(T entity);
}