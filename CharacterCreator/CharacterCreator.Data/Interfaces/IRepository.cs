namespace CharacterCreator.Data.Interfaces;

public interface IRepository<T>
{
    public IEnumerable<T> GetAllEntities();
    public T GetEntityById(string id);
    
    public void Save(T entity);
    public void Delete(string id);
    public void Update(T entity, string id);
    
}