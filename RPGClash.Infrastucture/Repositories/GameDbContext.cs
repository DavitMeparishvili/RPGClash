using Microsoft.EntityFrameworkCore;
using RPGClash.Domain.Entities;

namespace RPGClash.Infrastucture.Repositories
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<GameState> GameStates { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<PlayerCharacter> PlayerCharacters { get; set; }

        public virtual DbSet<UserRank> UserRanks { get; set; }

        public virtual DbSet<CharacterAction> Actions { get; set; }
    }
}
