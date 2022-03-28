using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class TopicConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Topic>().HasKey(m => m.TopicId);

            builder
                .Entity<Topic>()
                .HasOne(e => e.Subject)
                .WithMany(e => e.Topics)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}