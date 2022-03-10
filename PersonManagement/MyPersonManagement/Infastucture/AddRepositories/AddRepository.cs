using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.PersistenceDB.Implementations;
using PersonManagement.Rebository;
using PersonManagement.ServiceRebo;
using PersonManagment.PersistenceDB.Context;
using PersonManagment.PersistenceDB.Implementations;

namespace MyPersonManagement.Infastucture.AddRepositories
{
    public static class AddRepository
    {
        public static void AddRepo(this IServiceCollection service)
        {
            service.AddScoped<IPersonRepository, PersonServiceRepo>();
            service.AddScoped<IUserRepository, UserServiceRepo>();
            service.AddScoped<DbContext, PersonContext>();
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            
        }
    }
}
