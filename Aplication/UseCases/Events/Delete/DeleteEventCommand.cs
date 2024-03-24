using MediatR;

namespace Aplication.UseCases.Events.Delete
{
    public record DeleteEventCommand(Guid id) : IRequest;
}
