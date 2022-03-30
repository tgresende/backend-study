using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class SubjectCycleConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<SubjectCycle>().HasKey(m => m.SubjectCycleId);

            builder
                .Entity<SubjectCycle>()
                .HasOne(e => e.Subject)
                .WithMany(e => e.SubjectCycles)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}