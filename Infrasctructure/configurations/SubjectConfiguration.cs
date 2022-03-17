using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class SubjectConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasKey(m => m.SubjectId);

            builder
                .Entity<Subject>()
                .HasOne(e => e.Project)
                .WithMany(e => e.Subjects)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}