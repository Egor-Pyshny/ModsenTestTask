using Aplication.Interfaces;
using Aplication.UseCases.Events.FilteredList;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public EventRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddUser(Guid eventId, Guid userId)
        {
            var _event = (from e in _dbContext.Events
                          where e.Id == eventId
                          select e).FirstOrDefault() 
                          ?? throw new NotFoundException($"Event with id={eventId} not Found");
            var user = (from u in _dbContext.Users
                        where u.Id == userId
                        select u).FirstOrDefault() 
                        ?? throw new NotFoundException($"User with id={userId} not Found");
            _event.Users!.Add(user);
            _event.FreePlaces--;
            user.Events!.Add(_event);
        }

        public Guid Create(Event e)
        {
            var newEvent = _mapper.Map<EventDbModel>(e);
            newEvent.Id = Guid.NewGuid();
            _dbContext.Add(newEvent);
            return newEvent.Id;
        }

        public int Delete(Guid id)
        {
            int res = _dbContext.Events.Where(e => e.Id == id).ExecuteDelete();
            return res;
        }

        public void DeleteUser(Guid eventId, Guid userId)
        {
            var _event = (from e in _dbContext.Events.Include(t => t.Users)
                          where e.Id == eventId
                          select e).FirstOrDefault() 
                          ?? throw new NotFoundException($"Event with id={eventId} not Found");
            var user = (from u in _dbContext.Users.Include(t => t.Events)
                        where u.Id == userId
                        select u).FirstOrDefault() 
                        ?? throw new NotFoundException($"User with id={userId} not Found");
            _event.Users!.Remove(user);
            _event.FreePlaces++;
            user.Events!.Remove(_event);
        }

        public List<Event> GetAll(int page = 1, int size = 20)
        {
            var query = (from e in _dbContext.Catalog
                         select e)
                        .Skip((page - 1) * size)
                        .Take(size);
            var res = query.Select(c=>_mapper.Map<Event>(c)).ToList();
            return res;
        }

        public List<User> GetAllEventUsers(Guid id)
        {
            var _event = (from e in _dbContext.Events.Include(t => t.Users)
                          where e.Id == id
                          select e).FirstOrDefault() 
                          ?? throw new NotFoundException($"Event with id={id} not Found");
            var res = _event.Users!.Select(u => _mapper.Map<User>(u)).ToList();
            return res;
        }

        public List<Event> GetAllFiltered(FilterListCommand filter)
        {
            List<Expression<Func<EventDbModel, bool>>> filters = CompileFilters(filter);
            IQueryable<EventDbModel> query = _dbContext.Events;
            foreach (var f in filters)
            {
                query.Where(f);
            }
            var res = query.Select(c => _mapper.Map<Event>(c)).ToList();
            return res;
        }

        private List<Expression<Func<EventDbModel, bool>>> CompileFilters(FilterListCommand filter)
        {
            List<Expression<Func<EventDbModel, bool>>> filters = [];
            if (filter.city != null)
            { 
                filters.Add(t => t.City == filter.city);
            }
            if (filter.country != null)
            {
                filters.Add(t => t.Country == filter.country);
            }
            if (filter.organizer != null)
            {
                filters.Add(t => (t.OrganizerFirstName+" "+t.OrganizerSecondName) == filter.organizer);
            }
            if (filter.city != null)
            {
                filters.Add(t => DateOnly.FromDateTime(t.Time) == filter.date);
            }
            return filters;
        }

        public Event? GetById(Guid id)
        {
            var ev = (from e in _dbContext.Events.Include(t => t.Images)
                         where e.Id == id
                         select e).FirstOrDefault() 
                         ?? throw new NotFoundException($"Event with id={id} not Found");
            var res = _mapper.Map<Event>(ev);
            res.images = ev.Images!.Select(i => i.Path).ToList();
            return res;
        }

        public Event Update(Event newEvent)
        {
            var existingEvent = (from e in _dbContext.Events.Include(t => t.Images)
                      where e.Id == newEvent.id
                      select e).FirstOrDefault() 
                      ?? throw new NotFoundException($"Event with id={newEvent.id} not Found");
            int delta = newEvent.maxParticipants - existingEvent.MaxParticipants;
            existingEvent.Name = newEvent.name;
            existingEvent.Plan = newEvent.plan;
            existingEvent.Description = newEvent.description;
            existingEvent.Category = newEvent.category;
            existingEvent.OrganizerFirstName = newEvent.organizer.lastName;
            existingEvent.OrganizerSecondName = newEvent.organizer.firstName;
            existingEvent.SpickerFirstName = newEvent.spicker.firstName;
            existingEvent.SpickerSecondName = newEvent.spicker.lastName;
            existingEvent.Time = newEvent.time;
            existingEvent.Country = newEvent.address.country;
            existingEvent.City = newEvent.address.city;
            existingEvent.Street = newEvent.address.street;
            existingEvent.MaxParticipants = newEvent.maxParticipants;
            existingEvent.FreePlaces = existingEvent.FreePlaces + delta;
            _dbContext.Update(existingEvent);
            return _mapper.Map<Event>(existingEvent);
        }
    }
}
