using CarRepository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository.Data.DataContext
{
    public class CarContext:DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options)
        {
                
        }

        public DbSet<CarModel> models { get; set; }
    }
}
