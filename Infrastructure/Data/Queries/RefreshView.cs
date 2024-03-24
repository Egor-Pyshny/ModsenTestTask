using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Queries
{
    public static class RefreshView
    {
        public static void Refresh(AppDbContext db) => 
            db.Database.ExecuteSqlRaw(@"REFRESH MATERIALIZED VIEW catalogview;");
    }
}
