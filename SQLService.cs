public class SQLService<T> : ISQLService<T> where T : class
{
    private SchoolContext _context;

    public void initializeWithContext(SchoolContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        var set = _context.Set<T>();
        var result = set.ToList();
        return result;
    }

    public void Add(T entity)
    {
        if(entity != null)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            } 
            catch(Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
    }
    
    public void Delete()
    {

    }
  
    public void Update()
    {

    }

    public void Remove(int primaryKey)
    {
        var entity = _context.Set<T>().Find(primaryKey);
        if(entity != null)
        {
            _context.Remove<T>(entity);
            _context.SaveChanges();
        }
    }
} 