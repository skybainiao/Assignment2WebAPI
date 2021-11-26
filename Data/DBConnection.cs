using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class DBConnection : DbContext
    {
        
        public DbSet<Adult> Adult { set; get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\45527\RiderProjects\Assignment2WebAPI1\identifier.sqlite");
        }

    }
}