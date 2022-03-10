using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MyPersonManagement.Model.DTO;
using MyPersonManagement.Model.Request;
using PersonManagement.Model;
using PersonService.Model;
using System.Linq;

namespace MyPersonManagement.Infastucture.Mapping
{
    public static class RegisterMap
    {
        public static void AddRegisterMapping(this IServiceCollection services)
        {
            TypeAdapterConfig<Person, PersonReadDto>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<CreateRequestModel, Person>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Person, PersonRebo>
                .NewConfig()
                .Map(dest => dest.PersonPhones, src => src.Phones != null ? src.Phones.Select(x => new PersonPhone { Phone = x.Adapt<PhoneRepo>(), PersonId = src.Id, PhoneId = x.Id }) : default);

            TypeAdapterConfig<PersonRebo, Person>
                .NewConfig()
                .Map(dest => dest.Phones, src => src.PersonPhones.Select(x=>new {Phones=x.Phone }));

            TypeAdapterConfig<User, UserCreateModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<User, UserRepo>
                .NewConfig()
                .TwoWays();

            

            //TypeAdapterConfig<IdCard, IdCardRepo>
            //    .NewConfig()
            //    .TwoWays();
        }
            
                
        
    }
}
