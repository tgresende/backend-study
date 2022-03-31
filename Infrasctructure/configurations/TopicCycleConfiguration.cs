using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class TopicCycleConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<TopicCycle>().HasKey(m => m.TopicCycleId);

            builder
                .Entity<TopicCycle>()
                .HasOne(e => e.Topic)
                .WithMany(e => e.TopicCycles)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}