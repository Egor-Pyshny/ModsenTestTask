using MediatR;

namespace Aplication.UseCases.Events.Get
{
    public record GetByIdEventCommand(Guid id) : IRequest<EventDTO>;
}
