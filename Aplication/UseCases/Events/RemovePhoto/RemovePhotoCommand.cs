using MediatR;

namespace Aplication.UseCases.Events.RemovePhoto
{
    public record RemovePhotoCommand(Guid eventId, Guid imageId) : IRequest;
}
