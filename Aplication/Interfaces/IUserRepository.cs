using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserRepository
    {
        Guid Create(User u);
        User? LogIn(string email, string passw);
        User? GetById(Guid id);
        List<Event>? GetAllUserEvents(Guid id);
    }
}
