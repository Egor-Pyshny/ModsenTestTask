using MediatR;
using Microsoft.AspNetCore.Http;


namespace Aplication.UseCases.Events.AddPhoto
{
    public record AddPhotoCommand(Guid eventId, IFormFile file) : IRequest<Guid>;
}
