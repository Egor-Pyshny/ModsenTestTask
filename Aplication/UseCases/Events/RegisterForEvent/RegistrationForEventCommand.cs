using MediatR;

namespace Aplication.UseCases.Events.RegisterForEvent
{
    public record RegistrationForEventCommand(Guid userId, Guid eventId) : IRequest;
}
