using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Data.Migrations
{
    public class KeyStoreDbContext : DbContext
    {
        public KeyStoreDbContext(DbContextOptions<KeyStoreDbContext> options) : base(options) { }
        public DbSet<Key> Keys { get; set; }
        public DbSet<KeyCategory> KeyCategories { get; set; }
    }
}
