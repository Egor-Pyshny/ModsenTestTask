using Aplication.Interfaces;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Events.RemovePhoto
{
    public class RemovePhoto(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<RemovePhotoCommand>
    {
        public async Task Handle(RemovePhotoCommand request, CancellationToken cancellationToken)
        {
            string path = _repository.imageRepository.GetPath(request.imageId);
            _repository.imageRepository.Delete(request.imageId);
            _repository.fileAccessor.Delete(path);
        }
    }
}
