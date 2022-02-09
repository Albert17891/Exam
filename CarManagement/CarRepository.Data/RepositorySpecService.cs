using CarRepository.Data.DataContext;
using CarRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository.Data
{
    public class RepositorySpecService:ICarSpecRepository
    {
        private readonly CarContext context;

        public RepositorySpecService(CarContext context)
        {
            this.context = context;
        }

        

        public async Task Delete(int Id)
        {
            context.models.Where(x => x.Id == Id)
                .ToList().ForEach(x =>
                {
                    x.Abs = false;
                    x.PowerWindows = false;
                    x.Hatch = false;
                    x.Bluetooth = false;
                    x.Signaling = false;
                    x.ParkingControl = false;
                    x.Navigation = false;
                    x.OnboardComputer = false;
                    x.MultiWheel = false;
                });
            await context.SaveChangesAsync();
        }

        public Task<CarModel> GetSpecCar(int Id)
        {
            var res = context.models.FirstOrDefault(x => x.Id == Id);



            return Task.FromResult(res);
        }

        public async Task Update(int Id,CarModel carSpec)
        {
            context.models.Where(x => x.Id == Id)
                 .ToList().ForEach(x =>
                 {
                     x.Abs = carSpec.Abs;
                     x.PowerWindows = carSpec.PowerWindows;
                     x.Hatch = carSpec.Hatch;
                     x.Bluetooth = carSpec.Bluetooth;
                     x.Signaling = carSpec.Signaling;
                     x.ParkingControl = carSpec.ParkingControl;
                     x.Navigation = carSpec.Navigation;
                     x.OnboardComputer = carSpec.OnboardComputer;
                     x.MultiWheel = carSpec.MultiWheel;
                 });
           await context.SaveChangesAsync();
        }
    }
}
