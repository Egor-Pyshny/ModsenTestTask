using Aplication.Interfaces;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Events.List
{
    public class GetAll(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<ListEventCommand, List<EventDTO>>
    {
        public async Task<List<EventDTO>> Handle(ListEventCommand request, CancellationToken cancellationToken)
        {
            var temp = _repository.eventRepository.GetAll();
            var res = temp.Select(e => _mapper.Map<EventDTO>(e)).ToList();
            return res;
        }
    }
}
