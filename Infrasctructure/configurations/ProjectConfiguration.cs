using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class ProjectConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Project>().HasKey(m => m.ProjectId);

            builder.Entity<Project>()
                .HasMany(e => e.Subjects)
                .WithOne(e => e.Project);
        }
    }
}