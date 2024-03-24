using Aplication.UseCases.Events;
using Aplication.UseCases.Events.Create;
using Aplication.UseCases.Events.FilteredList;
using Aplication.UseCases.Events.Update;
using AutoMapper;
using WebApplication3.DTO.Catalog;
using WebApplication3.DTO.Event;

namespace WebApplication3.Mappers
{
    public class WebEventMapper : Profile
    {
        public WebEventMapper()
        {
            CreateMap<EventAddDTO, CreateEventCommand>();
            CreateMap<EventDTO, EventCatalogDTO>();
            CreateMap<EventUpdateDTO, UpdateEventCommand>();
            CreateMap<EventFilterDTO, FilterListCommand>();
        }
    }
}
