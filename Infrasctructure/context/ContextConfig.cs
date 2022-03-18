
using Microsoft.EntityFrameworkCore;
using Domain.entities;
using Infrasctructure.configurations;

namespace Infrasctructure.context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
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