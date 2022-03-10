using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.EfServices.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public BaseRepository(DbContext context)
        {

        }
        public Task<int> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(params object[] key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetPerson(params object[] key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
