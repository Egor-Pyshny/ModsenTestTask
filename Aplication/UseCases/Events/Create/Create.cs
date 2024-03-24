using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Aplication.UseCases.Events.Create
{
    public class Create(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<CreateEventCommand, (Guid, Guid)>
    {
        public async Task<(Guid, Guid)> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = _mapper.Map<Event>(request);
            newEvent.Validate();
            newEvent.images = [];
            Guid id = Guid.Empty;
            Guid imageId = Guid.Empty;
            string path = String.Empty;
            try
            {
                id = _repository.eventRepository.Create(newEvent);
                _repository.Save();
                path = _repository.fileAccessor.Save(request.file, id);
                imageId = _repository.imageRepository.Create(path, id);
                _repository.Save();
                _repository.Refresh();
            }
            catch(Exception ex)
            {
                try { _repository.eventRepository.Delete(id); } catch(Exception ex2) { }
                try { _repository.imageRepository.Delete(imageId); } catch(Exception ex2) { }
                try { _repository.fileAccessor.Delete(path); } catch(Exception ex2) { }
                throw ex;
            }
            return (id, imageId);
        }
    }
}
