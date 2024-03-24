using Domain.Entities;
using MediatR;

namespace Aplication.UseCases.Events.List
{
    public record ListEventCommand() : IRequest<List<EventDTO>>;
}
