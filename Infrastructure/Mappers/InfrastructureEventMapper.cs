using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataBaseModels;

namespace Infrastructure.Mappers
{
    public class InfrastructureEventMapper : Profile
    {
        public InfrastructureEventMapper()
        {
            CreateMap<Event, EventDbModel>()
                .ForMember(dest => dest.OrganizerFirstName, src => src.MapFrom(t => t.organizer.firstName))
                .ForMember(dest => dest.OrganizerSecondName, src => src.MapFrom(t => t.organizer.lastName))
                .ForMember(dest => dest.SpickerFirstName, src => src.MapFrom(t => t.spicker.firstName))
                .ForMember(dest => dest.SpickerSecondName, src => src.MapFrom(t => t.spicker.lastName))
                .ForMember(dest => dest.City, src => src.MapFrom(t => t.address.city))
                .ForMember(dest => dest.Country, src => src.MapFrom(t => t.address.country))
                .ForMember(dest => dest.Street, src => src.MapFrom(t => t.address.street))
                .ForMember(dest => dest.Images, src => src.Ignore()).ReverseMap();

            CreateMap<CatalogView, Event>()
                .ForMember(
                dest => dest.images, 
                src => src.MapFrom(c => c.Images.Split(' ', StringSplitOptions.None)))
                .ForMember(
                dest => dest.organizer,
                src => src.MapFrom(t => Person.Create(t.OrganizerFirstName, t.OrganizerSecondName)))
                .ForMember(
                dest => dest.address,
                src => src.MapFrom(t => Address.Create(t.Country, t.City, "null")));
        }
    }
}
