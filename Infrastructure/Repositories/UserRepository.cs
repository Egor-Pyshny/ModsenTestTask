using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public UserRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid Create(User u)
        {
            var newUser = _mapper.Map<UserDbModel>(u);
            newUser.Id = Guid.NewGuid();
            _dbContext.Add(newUser);
            return newUser.Id;
        }

        public List<Event>? GetAllUserEvents(Guid id)
        {
            var users = (from e in _dbContext.Users.Include(t => t.Events)
                          where e.Id == id
                          select e).FirstOrDefault() 
                          ?? throw new NotFoundException($"User with id={id} not Found");
            var res = users.Events!.Select(e => _mapper.Map<Event>(e)).ToList();
            return res;
        }

        public User? LogIn(string email, string passw)
        {
            var us = (from u in _dbContext.Users
                      where u.Email == email && u.Password == passw
                      select u).FirstOrDefault()
                      ?? throw new NotFoundException($"User with email={email} not Found");
            var res = _mapper.Map<User>(us);
            return res;
        }

        public User? GetById(Guid id)
        {
            var us = (from u in _dbContext.Users
                      where u.Id == id
                      select u).FirstOrDefault() 
                      ?? throw new NotFoundException($"User with id={id} not Found");
            var res = _mapper.Map<User>(us);
            return res;
        }
    }
}
