using Aplication.Interfaces;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Events.AddPhoto
{
    public class AddPhoto(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<AddPhotoCommand, Guid>
    {
        public async Task<Guid> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            var _event = _repository.eventRepository.GetById(request.eventId);
            Guid imageId = Guid.Empty;
            string path = String.Empty;
            try 
            {
                path = _repository.fileAccessor.Save(request.file, _event.id);
                imageId = _repository.imageRepository.Create(path, _event.id);
                _repository.Save();
                _repository.Refresh();
            }
            catch (Exception ex) 
            {
                try { _repository.imageRepository.Delete(imageId); } catch (Exception ex2) { }
                try { _repository.fileAccessor.Delete(path); } catch (Exception ex2) { }
                throw ex;
            }
            return imageId;
        }
    }
}
