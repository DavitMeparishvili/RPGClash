using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;

namespace RPGClash.Infrastucture.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly GameDbContext _gameDbContext;

        public PlayerRepository(GameDbContext gameDbContext) : base(gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public async Task<Player> GetPlayerAsync(int playerId, Func<IQueryable<Player>, IQueryable<Player>> includeFunc = null)
        {
            return await FindFirstOrDefaultByCondition(p => p.Id == playerId, includeFunc);
        }
    }
}
