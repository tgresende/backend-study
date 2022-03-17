
using Microsoft.EntityFrameworkCore;
using Domain.entities;
using Infrasctructure.configurations;

namespace Infrasctructure.context
{
    public class ContextConfig : DbContext
    {
        public ContextConfig(DbContextOptions<ContextConfig> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ProjectConfiguration.Configure(builder);
            SubjectConfiguration.Configure(builder);

            base.OnModelCreating(builder);
        }
    }
}