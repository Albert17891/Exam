using Microsoft.EntityFrameworkCore;
using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.PersistenceDB.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly DbContext _context;

        private readonly DbSet<T> _dbSet;
        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Table { get { return _dbSet; } }


       
        public Task<List<T>> GetAll()
        {
          return  _dbSet.ToListAsync();
        }
        public async Task<T> Get(params object[] key)
        {
            return await _dbSet.FindAsync(key);
        }

       

        public async Task Create(T entity)
        {
           await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(params object[] key)
        {

            var res = await Get(key);
            _dbSet.Remove(res);
            
        }

        

      

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
