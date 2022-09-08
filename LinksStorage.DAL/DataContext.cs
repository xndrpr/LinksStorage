using LinksStorage.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinksStorage.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<LinkEntity>? Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Database.db");
            var dbPath = @"D:\Programming\Projects\LinksStorage\LinksStorage\DB\Database.db";
            optionsBuilder.UseSqlite("Data Source = " + dbPath);
            base.OnConfiguring(optionsBuilder);
        }

        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }
    }
}
