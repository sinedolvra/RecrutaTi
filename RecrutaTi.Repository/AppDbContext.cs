using Microsoft.EntityFrameworkCore;
using RecrutaTi.Domain.Entities;
using RecrutaTi.Repository.Mappings;

namespace RecrutaTi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Job> Jobs;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobMapping());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}