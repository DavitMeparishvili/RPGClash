using RPGClash.Domain.Entities;
using RPGClash.GameEngine.Dtos;

namespace RPGClash.GameEngine.GameProcess.Abstract
{
    public interface IGameProcessManager
    {
        public Task<GameState> PlayerMakeMoveAsync(MakeMoveDto dto);
    }
}
