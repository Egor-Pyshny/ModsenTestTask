using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Data
{
    public class TestDbContext : AppDbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(
                    "Host=localhost;" +
                "Port=5432;" +
                "Database=modsen;" +
                "Username=postgres;" +
                "Password=postgres", x => x.MigrationsAssembly("Infrastructure")
                ).Options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=modsen_test;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
