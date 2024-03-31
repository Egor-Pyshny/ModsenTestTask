using Aplication.Mappers;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Utils
{
    public static class SetUpUtils
    {
        public static TestDbContext CreateDataBaseAndApplyMigrations() 
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
            var _context = new TestDbContext(dbContextOptions);
            _context.Database.Migrate();
            ClearAllTables();
            return _context;
        }

        public static void ClearAllTables()
        {
            var masterConnectionString = new NpgsqlConnectionStringBuilder();
            masterConnectionString.Host = "localhost";
            masterConnectionString.Port = 5432;
            masterConnectionString.Username = "postgres";
            masterConnectionString.Password = "postgres";
            masterConnectionString.Database = "modsen_test";
            using (var connection = new NpgsqlConnection(masterConnectionString.ConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM \"tbl_user\" CASCADE", connection))
                {
                    command.ExecuteNonQuery();
                }
                using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM \"tbl_event\" CASCADE", connection))
                {
                    command.ExecuteNonQuery();
                }
                using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM \"tbl_images\" CASCADE", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static IMapper GetAllMappers()
        {
            InfrastructureUserMapper m1 = new InfrastructureUserMapper();
            InfrastructureEventMapper m2 = new InfrastructureEventMapper();

            ApplicationUserMapper m3 = new ApplicationUserMapper();
            ApplicationEventMapper m4 = new ApplicationEventMapper();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(m1);
                cfg.AddProfile(m2);
                cfg.AddProfile(m3);
                cfg.AddProfile(m4);
            });

            return new Mapper(configuration);
        }
    }
}
