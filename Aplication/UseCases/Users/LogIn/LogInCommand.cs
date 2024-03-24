using MediatR;

namespace Aplication.UseCases.Users.LogIn
{
    public record LogInCommand(string Email, string Password) : IRequest<UserDTO>;
}
