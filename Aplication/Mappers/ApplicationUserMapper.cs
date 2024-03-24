using Aplication.UseCases.Users;
using Aplication.UseCases.Users.Registration;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Mappers
{
    public class ApplicationUserMapper : Profile
    {
        public ApplicationUserMapper()
        { 
            CreateMap<User, UserDTO>();

            CreateMap<RegistrationCommand, User>()
                .ForMember(dest => dest.registrationDate, src => src.MapFrom(t => DateTime.UtcNow));
        }
    }
}
