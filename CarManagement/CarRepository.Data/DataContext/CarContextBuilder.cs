using CarRepository.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace CarRepository.Data.DataContext
{
    public class CarContextBuilder : IDesignTimeDbContextFactory<CarContext>
    {
        //private readonly string _connection;
        //public CarContextBuilder(IOptions<ConnectionStrings> options )
        //{
        //    _connection = options.Value.DefaultConnection;
        //}
        public CarContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Car;Trusted_Connection=True;");

            return new CarContext(optionsBuilder.Options);
        }
    }
}
