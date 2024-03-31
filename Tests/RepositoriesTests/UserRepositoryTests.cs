using Infrastructure.Data.DataBaseModels;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Tests.Utils;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;

namespace UserRepositoryTest
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private static TestDbContext? _context;
        private static UserRepository _repository;
        private static Guid userId = Guid.Empty, imageId, eventId;

        [SetUpFixture]
        public class SetUpClass
        {
            [OneTimeSetUp]
            public void SetUp()
            {
                _context = SetUpUtils.CreateDataBaseAndApplyMigrations();
                _context.Users.Add(
                        new UserDbModel()
                        {
                            Email = "test1@test.com",
                            FirstName = "Ftester",
                            SecondName = "Ftester",
                            ThirdName = "Ftester",
                            Id = userId = Guid.NewGuid(),
                            Password = "tester_password",
                            RegistrationDate = DateTime.UtcNow,
                            Events = new List<EventDbModel>() {
                                new EventDbModel()
                                {
                                    Category = "test",
                                    City = "test",
                                    Country = "test",
                                    Street = "test",
                                    Description = "test",
                                    FreePlaces = 20,
                                    Id = eventId = Guid.NewGuid(),
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
                                }
                            },
                        }
                    );
                _context.SaveChanges();
                IMapper mapper = SetUpUtils.GetAllMappers();
                _repository = new UserRepository(_context, mapper);
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
            var u = User.Create("Stester", "Stester", "Stester", "test2@test.com", "tester_password", DateTime.UtcNow);
            var id = _repository.Create(u);
            _context.SaveChanges();
            id.Should().NotBeEmpty();
        }

        [Test, Order(2)]
        public void GetAllUserEventsTest()
        {
            var events = _repository.GetAllUserEvents(userId);
            events.Should().HaveCount(1);
            events[0].id.Should().Be(eventId);
        }

        [Test, Order(3)]
        public void LogInTest()
        {
            var user = _repository.LogIn("test1@test.com", "tester_password");
            user.Should().NotBeNull();
            user.id.Should().Be(userId);
        }

        [Test, Order(4)]
        public void GetByIdTest()
        {
            var user = _repository.GetById(userId);
            user.Should().NotBeNull();
            user.firstName.Should().Be("Ftester");
            user.secondName.Should().Be("Ftester");
            user.thirdName.Should().Be("Ftester");
            user.email.Should().Be("test1@test.com");
            user.password.Should().Be("tester_password");
        }
    }
}
