using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Repositories;
using Tests.Utils;

namespace ImageRepositoryTest
{
    [TestFixture]
    public class ImageRepositoryTests
    {

        private static TestDbContext? _context;
        private static ImageRepository _repository;
        private static Guid eventId = Guid.Empty, imageId;

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
                    );
                _context.SaveChanges();
                _repository = new ImageRepository(_context);
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
            imageId = _repository.Create("Test.path", eventId);
            _context.SaveChanges();
            imageId.Should().NotBeEmpty();
        }

        [Test, Order(2)]
        public void GetPathTest()
        {
            var path = _repository.GetPath(imageId);
            path.Should().Be("Test.path");
        }

        [Test, Order(3)]
        public void DeleteTest()
        {
            int res = _repository.Delete(imageId);
            _context.SaveChanges();
            res.Should().Be(1);
        }
    }
}
