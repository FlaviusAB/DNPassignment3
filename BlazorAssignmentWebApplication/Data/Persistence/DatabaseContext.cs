using System.Reflection;
using BlazorAssignmentWebApplication.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorAssignmentWebApplication.Data.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Family.db");
        }
        
    }
}