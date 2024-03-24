using Aplication.Interfaces;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Events.Get
{
    public class GetById(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<GetByIdEventCommand, EventDTO>
    {
        public async Task<EventDTO> Handle(GetByIdEventCommand request, CancellationToken cancellationToken)
        {
            var res = _repository.eventRepository.GetById(request.id);
            return _mapper.Map<EventDTO>(res);
        }
    }
}
