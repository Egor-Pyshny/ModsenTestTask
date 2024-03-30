using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Tests.RepositoriesTests
{
    [TestFixture]
    public class ImageRepositoryTests
    {

        private TestDbContext? _context;
        private ImageRepository _repository;
        private Guid eventId, imageId;

        public void SetUp()
        {
            var masterConnectionString = new NpgsqlConnectionStringBuilder();
            masterConnectionString.Host = "localhost";            
            masterConnectionString.Port = 5432;
            masterConnectionString.Username = "postgres";
            masterConnectionString.Password = "postgres";
            using (var connection = new NpgsqlConnection(masterConnectionString.ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT 1 FROM pg_database WHERE datname='modsen_test'";
                    var result = command.ExecuteScalar();
                    if (!(result != null && result != DBNull.Value))
                    {
                        command.CommandText = $"CREATE DATABASE \"modsen_test\"";
                        command.ExecuteNonQuery();
                        command.CommandText = $"GRANT ALL PRIVILEGES ON DATABASE \"modsen_test\" TO \"postgres\"";
                        command.ExecuteNonQuery();
                    }
                }
            }
            string connectionStr = 
                "Host=localhost;" +
                "Port=5432;" +
                "Database=modsen_test;" +
                "Username=postgres;" +
                "Password=postgres"
                ;
            var dbContextOptions = new DbContextOptionsBuilder<TestDbContext>()
                .UseNpgsql(connectionStr).Options;
            _context = new TestDbContext(dbContextOptions);
            _context.Database.Migrate();
            _context.Events.Add(
                    new EventDbModel(){ 
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

        [TearDown]
        public void TearDown() {
            _context!.Dispose();
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
            res.Should().Be(1);
        }
    }
}
