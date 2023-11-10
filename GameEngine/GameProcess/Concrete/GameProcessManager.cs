using RPGClash.Domain.Entities;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Game.Abstract;
using RPGClash.GameEngine.GameProcess.Abstract;

namespace RPGClash.GameEngine.GameProcess.Concrete
{
    public class GameProcessManager : IGameProcessManager
    {
        private readonly IGameStateManager _gameStateManager;
        
        public GameProcessManager(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }
        
        public async Task<GameState> PlayerMakeMoveAsync(MakeMoveDto dto)
        {
            var gameState = await _gameStateManager.GetGameStateAsync(dto.GameStateId);
        }
    }
}
