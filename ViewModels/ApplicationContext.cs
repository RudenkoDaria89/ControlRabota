using Microsoft.EntityFrameworkCore;

namespace BookAccounting.Models
{
    class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Publish> Publishes { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BookAccounting.db");
        }
    }
}
