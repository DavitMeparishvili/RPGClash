using Microsoft.EntityFrameworkCore;
using RPGClash.Domain.Entities;
using System.Reflection;

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

        public virtual DbSet<DbCharacter> Characters { get; set; }

        public virtual DbSet<UserRank> UserRanks { get; set; }

        public virtual DbSet<CharacterAction> Actions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
