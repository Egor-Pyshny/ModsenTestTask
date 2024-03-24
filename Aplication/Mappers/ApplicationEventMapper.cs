using Aplication.UseCases.Events;
using Aplication.UseCases.Events.Create;
using Aplication.UseCases.Events.Update;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Mappers
{
    public class ApplicationEventMapper : Profile
    {
        public ApplicationEventMapper()
        {
            CreateMap<CreateEventCommand, Event>()
                .ForMember(
                dest => dest.spicker,
                src => src.MapFrom(t => Person.Create(t.spickerFirstName, t.spickerSecondName)))
                .ForMember(
                dest => dest.organizer,
                src => src.MapFrom(t => Person.Create(t.organizerFirstName, t.organizerSecondName)))
                .ForMember(
                dest => dest.address,
                src => src.MapFrom(t => Address.Create(t.country, t.city, t.street)))
                .ForMember(
                dest => dest.freePlaces,
                src => src.MapFrom(t => t.maxParticipants));

            CreateMap<UpdateEventCommand, Event>()
                .ForMember(
                dest => dest.spicker,
                src => src.MapFrom(t => Person.Create(t.spickerFirstName, t.spickerSecondName)))
                .ForMember(
                dest => dest.organizer,
                src => src.MapFrom(t => Person.Create(t.organizerFirstName, t.organizerSecondName)))
                .ForMember(
                dest => dest.address,
                src => src.MapFrom(t => Address.Create(t.country, t.city, t.street)))
                .ForMember(
                dest => dest.freePlaces,
                src => src.Ignore());

            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.organizerFirstName, src => src.MapFrom(t => t.organizer.firstName))
                .ForMember(dest => dest.organizerSecondName, src => src.MapFrom(t => t.organizer.lastName))
                .ForMember(dest => dest.spickerFirstName, src => src.MapFrom(t => t.spicker.firstName))
                .ForMember(dest => dest.spickerSecondName, src => src.MapFrom(t => t.spicker.lastName))
                .ForMember(dest => dest.city, src => src.MapFrom(t => t.address.city))
                .ForMember(dest => dest.country, src => src.MapFrom(t => t.address.country))
                .ForMember(dest => dest.street, src => src.MapFrom(t => t.address.street));
        }
    }
}
