using RPGClash.Domain.Entities;

namespace RPGClash.Domain.Repositories
{
    public interface IGameStateRepo
    {
        public Task<GameState> AddGameStateAsync(GameState domainModel);
        public Task<GameState> GetGameStateAsync(int gameStateId, Func<IQueryable<GameState>, IQueryable<GameState>> includeFunc = null);
    }
}
