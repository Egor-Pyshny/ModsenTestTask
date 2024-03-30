using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<UserDbModel> Users { get; set; } = null!;
        public virtual DbSet<EventDbModel> Events { get; set; } = null!;
        public virtual DbSet<CatalogView> Catalog { get; set; } = null!;
        public virtual DbSet<ImageDbModel> Images { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        public AppDbContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=modsen;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
