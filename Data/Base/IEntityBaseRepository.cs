using project_asp.Models;

namespace project_asp.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, iEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
