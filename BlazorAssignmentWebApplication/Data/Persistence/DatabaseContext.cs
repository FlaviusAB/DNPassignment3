using BlazorAssignmentWebApplication.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorAssignmentWebApplication.Data.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Adult> Adults { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Family.db");
        }
        
    }
}