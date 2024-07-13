namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
    }
}
