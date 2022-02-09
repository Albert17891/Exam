using CarRepository.Data.DataContext;
using CarRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository.Data
{
    public class RepositoryService : IRepositoryService
    {

        private readonly CarContext context;

        public RepositoryService(CarContext context)
        {
            this.context = context;
        }

        public Task CreateCar(CarModel car)
        {
            context.Add(car);
            context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task Delete(int Id)
        {
            var car = GetCar(Id);
            if (car == null)
            {
                throw new Exception("Car Not Found");
            }
            context.Remove(car);

           await context.SaveChangesAsync();

        }

        public Task<CarModel> GetCar(int Id)
        {
            var res = context.models.FirstOrDefault(x => x.Id == Id);

            return Task.FromResult(res);
        }

        public  Task<List<CarModel>> GetCars()
        {
            var res = context.models.ToList();

            return Task.FromResult(res);
        }

        public async Task Update(CarModel car)
        {
            var res = GetCar(car.Id);
            if (res == null)
            {
                throw new Exception("Car Not Found");
            }

            context.Update(res);

           await context.SaveChangesAsync();

          
        }
    }
}
