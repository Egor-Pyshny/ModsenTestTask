using Aplication.Interfaces;
using MediatR;

namespace Aplication.UseCases.Events.RegisterForEvent
{
    public class RegisterForEvent(IUnitOfWork _repository)
        : IRequestHandler<RegistrationForEventCommand>
    {
        public async Task Handle(RegistrationForEventCommand request, CancellationToken cancellationToken)
        {
            _repository.eventRepository.AddUser(request.eventId, request.userId);
            _repository.Save();
            _repository.Refresh();
        }
    }
}
