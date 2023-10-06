using JEM_id_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JEM_id_API.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ArticleDto> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleDto>().HasKey(pk => pk.Id);
        }
    }
}
