using Aplication.UseCases.Users;
using MediatR;

namespace Aplication.UseCases.Events.GetAllEventUsers
{
    public record GetAllEventUsersCommand(Guid id) : IRequest<List<UserDTO>>;
}
