using Aplication.Interfaces;
using Aplication.UseCases.Users;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Events.GetAllEventUsers
{
    public class GetAllEventUsers(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<GetAllEventUsersCommand, List<UserDTO>>
    {
        public async Task<List<UserDTO>> Handle(GetAllEventUsersCommand request, CancellationToken cancellationToken)
        {
            var users = _repository.eventRepository.GetAllEventUsers(request.id);
            var res = users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
            return res;
        }
    }
}
