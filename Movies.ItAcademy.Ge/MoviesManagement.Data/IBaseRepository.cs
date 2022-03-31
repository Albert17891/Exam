using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.Data
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        Task<List<T>> GetAllEntityAsync();
        Task<T> GetEntityByIdAsync(object key);
        Task CreateEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(T entity);
    }
}
