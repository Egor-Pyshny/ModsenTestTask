using Aplication.UseCases.Events.FilteredList;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IEventRepository
    {
        Guid Create(Event e);
        Event? GetById(Guid id);
        List<Event> GetAll(int page = 0, int size = 20);
        List<Event> GetAllFiltered(FilterListCommand filter);
        Event Update(Event e);
        int Delete(Guid id);
        List<User> GetAllEventUsers(Guid id);
        void AddUser(Guid eventId, Guid userId);
        void DeleteUser(Guid eventId, Guid userId);
    }
}
