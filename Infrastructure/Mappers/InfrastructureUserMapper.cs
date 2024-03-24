using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataBaseModels;

namespace Infrastructure.Mappers
{
    public class InfrastructureUserMapper : Profile
    {
        public InfrastructureUserMapper()
        {
            CreateMap<User, UserDbModel>().ReverseMap();
        }
    }
}
