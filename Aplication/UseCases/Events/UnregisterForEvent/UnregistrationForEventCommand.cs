using MediatR;

namespace Aplication.UseCases.Events.UnregisterForEvent
{
    public record UnegistrationForEventCommand(Guid userId, Guid eventId) : IRequest;
}
