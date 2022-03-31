using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.Data.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return _dbSet.AsNoTracking(); }
        }


        public async Task<List<T>> GetAllEntityAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetEntityByIdAsync(object key)
        {
            return await _dbSet.FindAsync(key);
        }
        public async Task CreateEntityAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }




    }
}
