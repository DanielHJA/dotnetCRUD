public interface ISQLService<T>
{
    public void initializeWithContext(SchoolContext context);
    public void Remove(int primaryKey);
    public List<T> GetAll();
    public void Add(T entity);
    public void Delete();
    public void Update();
}