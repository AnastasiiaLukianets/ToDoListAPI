namespace ToDoListAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAll(); // GET all entities
        Task<T?> GetById(int id); // GET{id}
        Task<T?> Add(T entity); // POST
        Task<T?> Update(T entity); // PUT
        Task<T?> DeleteById(int id); // DELETE{id}
    }
}
