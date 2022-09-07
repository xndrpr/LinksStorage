using LinksStorage.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinksStorage.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity>? Users { get; set; }
        public DbSet<LinkEntity>? Links { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}
