using Aplication.Interfaces;
using AutoMapper;
using MediatR;

namespace Aplication.UseCases.Users.LogIn
{
    public class LogIn(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<LogInCommand, UserDTO>
    {
        public async Task<UserDTO> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var res = _repository.userRepository.LogIn(request.Email, request.Password);
            return _mapper.Map<UserDTO>(res);
        }
    }
}
