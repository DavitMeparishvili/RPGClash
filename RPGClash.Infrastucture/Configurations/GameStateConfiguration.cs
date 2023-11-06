using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGClash.Domain.Entities;


namespace RPGClash.Infrastucture.Configurations
{
    public class GameStateConfiguration : IEntityTypeConfiguration<GameState>
    {
        public void Configure(EntityTypeBuilder<GameState> builder)
        {
            // Define the relationship between Room and Player1
            builder.HasOne(r => r.Player1)
                .WithMany()
                .HasForeignKey(r => r.Player1Id)
                .OnDelete(DeleteBehavior.Restrict); // You can choose the appropriate delete behavior

            // Define the relationship between Room and Player2
            builder.HasOne(r => r.Player2)
                .WithMany()
                .HasForeignKey(r => r.Player2Id)
                .OnDelete(DeleteBehavior.Restrict); // You can choose the appropriate delete behavior
        }
    }
}
