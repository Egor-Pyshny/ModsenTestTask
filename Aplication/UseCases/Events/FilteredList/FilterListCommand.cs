using MediatR;

namespace Aplication.UseCases.Events.FilteredList
{
    public record FilterListCommand(string country, 
        string city, string organizer, DateOnly date) : IRequest<List<EventDTO>>;
}
