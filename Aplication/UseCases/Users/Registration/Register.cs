using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Validators;
using MediatR;

namespace Aplication.UseCases.Users.Registration
{
    public class Register(IUnitOfWork _repository, IMapper _mapper)
        : IRequestHandler<RegistrationCommand, Guid>
    {
        public async Task<Guid> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            newUser.Validate();
            Guid id = _repository.userRepository.Create(newUser);
            _repository.Save();
            _repository.Refresh();
            return id;
        }
    }
}
