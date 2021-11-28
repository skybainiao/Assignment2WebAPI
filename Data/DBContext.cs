using LoginExample.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class DBContext : DbContext
    {
        
        public DbSet<Adult> Adults { set; get; }
        
        public DbSet<User> Users { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = identifier.db");
        }

    }
}