using RPGClash.Domain.Entities;

namespace RPGClash.Domain.Repositories
{
    public interface IPlayerRepository
    {
        public Task<Player> GetPlayerAsync(int playerId, Func<IQueryable<Player>, IQueryable<Player>> includeFunc = null);
    }
}
