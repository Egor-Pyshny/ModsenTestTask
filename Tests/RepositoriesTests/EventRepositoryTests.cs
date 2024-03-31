using AutoMapper;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Tests.Utils;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Data.Queries;
using Microsoft.EntityFrameworkCore;

namespace EventRepositoryTest
{
    public class EventRepositoryTests
    {
        [TestFixture]
        public class UserRepositoryTests
        {
            private static TestDbContext? _context;
            private static EventRepository _repository;
            private static UserRepository _helprepository;
            private static Guid eventId = Guid.Empty, userId;

            [SetUpFixture]
            public class SetUpClass
            {
                [OneTimeSetUp]
                public void SetUp()
                {
                    _context = SetUpUtils.CreateDataBaseAndApplyMigrations();
                    _context.Events.Add(
                        new EventDbModel()
                        {
                            Category = "test",
                            City = "test",
                            Country = "test",
                            Street = "test",
                            Description = "test",
                            FreePlaces = 20,
                            Id = Guid.NewGuid(),
                            MaxParticipants = 20,
                            OrganizerFirstName = "test",
                            OrganizerSecondName = "test",
                            SpickerFirstName = "test",
                            SpickerSecondName = "test",
                            Name = "test",
                            Plan = "test",
                            Time = DateTime.UtcNow,
                            Images = [],
                            Users = [],
                        });
                    _context.SaveChanges();
                    RefreshView.Refresh(_context);
                    IMapper mapper = SetUpUtils.GetAllMappers();
                    _repository = new EventRepository(_context, mapper);
                    _helprepository = new UserRepository(_context, mapper);
                }

                [OneTimeTearDown]
                public void RunAfterAnyTests()
                {
                    SetUpUtils.ClearAllTables();
                    _context!.Dispose();
                }
            }

            [Test, Order(1)]
            public void CreateTest()
            {
                eventId = _repository.Create(Event.Create("new_event", "test", "test", 
                    Person.Create("spicker", "spicker"), Person.Create("organizer", "organizer"),
                    DateTime.MaxValue, Address.Create("country", "city", "street"), "test", 10, 10, []));
                _context!.SaveChanges();
                RefreshView.Refresh(_context);
                eventId.Should().NotBeEmpty();
            }

            [Test, Order(2)]
            public void AddUserTest()
            {
                var u = User.Create("Stester", "Stester", "Stester", "test2@test.com", "tester_password", DateTime.UtcNow);
                userId = _helprepository.Create(u);
                _context.SaveChanges();
                _repository.AddUser(eventId, userId);
                _context.SaveChanges();
            }

            [Test, Order(3)]
            public void GetByIdTest()
            {
                var _event = _repository.GetById(eventId);
                _event.Should().NotBeNull();
                _event.name.Should().Be("new_event");
                _event.description.Should().Be("test");
                _event.plan.Should().Be("test");
                _event.spicker.firstName.Should().Be("spicker");
                _event.spicker.lastName.Should().Be("spicker");
                _event.organizer.firstName.Should().Be("organizer");
                _event.organizer.lastName.Should().Be("organizer");
                _event.address.city.Should().Be("city");
                _event.address.country.Should().Be("country");
                _event.address.street.Should().Be("street");
                _event.category.Should().Be("test");
                _event.maxParticipants.Should().Be(10);
                _event.freePlaces.Should().Be(9);
            }

            [Test, Order(4)]
            public void GetAllEventUsersTest()
            {
                var users = _repository.GetAllEventUsers(eventId);
                users.Should().HaveCount(1);
                users[0].id.Should().Be(userId);
            }

            [Test, Order(5)]
            public void DeleteUserTest()
            {
                _repository.DeleteUser(eventId, userId);
                _context.SaveChanges();
                _context.Events.Where(e => e.Id == eventId).First().Users.Should().HaveCount(0);
            }

            [Test, Order(7)]
            public void UpdateTest()
            {
                var newEvent = Event.Create("updated", "updated", "updated",
                    Person.Create("updated", "updated"), Person.Create("updated", "updated"),
                    DateTime.MaxValue, Address.Create("updated", "updated", "updated"), "updated", 10, 10, []);
                newEvent.SetId(eventId);
                _repository.Update(newEvent);
                _context.SaveChanges();
                var _event = _repository.GetById(eventId);
                _event.Should().NotBeNull();
                _event.name.Should().Be("updated");
                _event.description.Should().Be("updated");
                _event.plan.Should().Be("updated");
                _event.spicker.firstName.Should().Be("updated");
                _event.spicker.lastName.Should().Be("updated");
                _event.organizer.firstName.Should().Be("updated");
                _event.organizer.lastName.Should().Be("updated");
                _event.address.city.Should().Be("updated");
                _event.address.country.Should().Be("updated");
                _event.address.street.Should().Be("updated");
                _event.category.Should().Be("updated");
                _event.maxParticipants.Should().Be(10);
                _event.freePlaces.Should().Be(10);
            }            
            
            [Test, Order(8)]
            public void DeleteTest()
            {
                int res = _repository.Delete(eventId);
                res.Should().Be(1);
            }
        }
    }
}
