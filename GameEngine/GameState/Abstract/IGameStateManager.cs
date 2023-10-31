using RPGClash.Domain.Entities;
using RPGClash.GameEngine.Dtos;

namespace RPGClash.GameEngine.Game.Abstract
{
    public interface IGameStateManager
    {
        public Task <GameState> InitiateGameAsync(List<GameStateDto> gameState);
    }
}
