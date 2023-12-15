using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Areas.Admin.Models;
using System.Reflection;

namespace Portfolio.Contexts
{
    public class PortfolioDbContext : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PortfolioDb;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Person> Persons { get; set; }
      
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
       
        public DbSet<Service> Services { get; set; }
    }
    
}
