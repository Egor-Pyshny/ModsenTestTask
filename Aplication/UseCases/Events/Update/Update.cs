using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Events.Event;
using Domain.Validators;
using MediatR;

namespace Aplication.UseCases.Events.Update
{
    public class Update(IUnitOfWork _repository, IMapper _mapper, IMediator _mediator)
        : IRequestHandler<UpdateEventCommand, EventDTO>
    {
        public async Task<EventDTO> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var myEvent = _mapper.Map<Event>(request);
            myEvent.Validate();

            var res = _repository.eventRepository.Update(myEvent);

            var users = _repository.eventRepository.GetAllEventUsers(request.id);
            List<string> emails = users.Select(u => u.email).ToList();
            var modifyCmd = new EventModifyEvent(request!.name, emails, EventModifyEvent.Action.UPDATE);
            await _mediator.Publish(modifyCmd);

            _repository.Save();
            _repository.Refresh();
            return _mapper.Map<EventDTO>(res);
        }
    }
}
