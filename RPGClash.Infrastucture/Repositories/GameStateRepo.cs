using Microsoft.EntityFrameworkCore;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;

namespace RPGClash.Infrastucture.Repositories
{
    public class GameStateRepo : RepositoryBase<GameState>, IGameStateRepo
    {
        private readonly GameDbContext _gameDbContext;

        public GameStateRepo(GameDbContext gameDbContext) : base(gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<GameState> AddGameStateAsync(GameState domainModel)
        {
            return await Create(domainModel);
        }

        public async Task<GameState?> GetGameStateAsync(int gameStateId, Func<IQueryable<GameState>, IQueryable<GameState>> includeFunc = null)
        {
            return (await FindByCondition(gs => gs.Id == gameStateId, includeFunc)).FirstOrDefault();
        }
    }
}
