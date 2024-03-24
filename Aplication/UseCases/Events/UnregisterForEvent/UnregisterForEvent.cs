using Aplication.Interfaces;
using MediatR;

namespace Aplication.UseCases.Events.UnregisterForEvent
{
    public class UnregisterForEvent(IUnitOfWork _repository)
        : IRequestHandler<UnegistrationForEventCommand>
    {
        public async Task Handle(UnegistrationForEventCommand request, CancellationToken cancellationToken)
        {
            _repository.eventRepository.DeleteUser(request.eventId, request.userId);
            _repository.Save();
            _repository.Refresh();
        }
    }
}
