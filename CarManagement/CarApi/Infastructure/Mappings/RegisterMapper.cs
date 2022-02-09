using CarApi.Model.DTO;
using CarApi.Model.Request;
using CarRepository.Model;
using CarService.Model;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace CarApi.Infastructure.Mappings
{
    public static class RegisterMapper
    {
        public static void AddRegMapper( this IServiceCollection service)
        {
            TypeAdapterConfig<Car, CarReadDto>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Car, CarCreateRequest>
                .NewConfig()
                .TwoWays();


            TypeAdapterConfig<Car, CarModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Car,UpdateCarRequest>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<CarSpecDto, CarSpecification>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<CarSpecification, CarModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<CarSpecification, UpdateCarSpecific>
                .NewConfig()
                .TwoWays();



        }
    }
}
