using Aplication.Interfaces;
using Aplication.UseCases.Events;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Users.GetAllUserEvents
{
    public class GetAllUserEvents(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<GetAllUserEventsCommand, List<EventDTO>>
    {
        public async Task<List<EventDTO>> Handle(GetAllUserEventsCommand request, CancellationToken cancellationToken)
        {
            var events = _repository.userRepository.GetAllUserEvents(request.userID);
            var res = events!.Select(e => _mapper.Map<EventDTO>(e)).ToList();
            return res;
        }
    }
}
