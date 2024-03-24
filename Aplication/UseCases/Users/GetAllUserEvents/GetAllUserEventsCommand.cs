using Aplication.UseCases.Events;
using MediatR;

namespace Aplication.UseCases.Users.GetAllUserEvents
{
    public record GetAllUserEventsCommand(Guid userID) : IRequest<List<EventDTO>>;
}
