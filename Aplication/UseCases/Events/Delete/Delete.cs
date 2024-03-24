using Aplication.Interfaces;
using Domain.Events.Event;
using MediatR;

namespace Aplication.UseCases.Events.Delete
{
    public class Delete(IUnitOfWork _repository, IMediator _mediator)
        : IRequestHandler<DeleteEventCommand>
    {
        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var e = _repository.eventRepository.GetById(request.id);
            var users = _repository.eventRepository.GetAllEventUsers(request.id);
            List<string> emails = users.Select(u => u.email).ToList();
            var modifyCmd = new EventModifyEvent(e!.name, emails, EventModifyEvent.Action.DELETE);
            await _mediator.Publish(modifyCmd);
            _repository.eventRepository.Delete(request.id);
            _repository.Save();
            _repository.Refresh();
        }
    }    
}
