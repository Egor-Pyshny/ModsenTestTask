using Aplication.UseCases.Users.Registration;
using AutoMapper;
using WebApplication3.DTO.User;

namespace WebApplication3.Mappers
{
    public class WebUserMapper : Profile
    {
        public WebUserMapper()
        {
            CreateMap<UserAddDTO, RegistrationCommand>();
        }
    }
}
