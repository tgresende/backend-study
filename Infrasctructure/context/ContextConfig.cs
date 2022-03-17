
using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.context
{
    public class ContextConfig : DbContext
    {
        public ContextConfig(DbContextOptions<ContextConfig> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
               builder.Entity<Project>().HasKey(m => m.ProjectId);
               base.OnModelCreating(builder);
        }
    }
}