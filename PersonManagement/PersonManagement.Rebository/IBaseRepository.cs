using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Rebository
{
    public  interface IBaseRepository<T>
    {

        IQueryable<T> Table { get; }
        Task<List<T>> GetAll();

        Task<T> Get(params object[] key);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(params object[] key);

    }
}
