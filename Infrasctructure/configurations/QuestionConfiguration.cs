using Microsoft.EntityFrameworkCore;
using Domain.entities;

namespace Infrasctructure.configurations
{
    public static class QuestionConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Question>().HasKey(m => m.QuestionId);

            builder
                .Entity<Question>()
                .HasOne(e => e.Topic)
                .WithMany(e => e.Questions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}