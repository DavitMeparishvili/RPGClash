using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;
using RPGClash.GameEngine.CharacterAction.Abstract;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using RPGClash.GameEngine.Game.Abstract;
using RPGClash.GameEngine.GameProcess.Abstract;

namespace RPGClash.GameEngine.GameProcess.Concrete
{
    public class GameProcessManager : IGameProcessManager
    {
        private readonly IGameStateManager _gameStateManager;
        
        private readonly IActionsManager _actionsManager;

        private readonly IPlayerRepository _playerRepository;

        public GameProcessManager(IGameStateManager gameStateManager, IActionsManager actionsManager, IPlayerRepository playerRepository)
        {
            _gameStateManager = gameStateManager;
            _actionsManager = actionsManager;
            _playerRepository = playerRepository;
        }
        
        public async Task<GameState> PlayerMakeMoveAsync(MakeMoveDto dto)
        {
            var gameState =  await _gameStateManager.GetGameStateAsync(dto.GameStateId);

            if (!gameState.Player1.DoneWithMoves)
            {
                if (gameState.Player1.UserId == dto.UserId)
                {
                    
                }
                else
                {
                    throw new GameException("It is Player 1's turn to make a move");
                }
            }

            if (!gameState.Player2.DoneWithMoves)
            {
                if (gameState.Player2.UserId == dto.UserId)
                {

                }
                else
                {
                    throw new Exception("It is Player 2's turn to make a move");
                }
            }

            throw new GameException("Player was not found");

        }


        private void DoTargetedAction(Player player, Actions action, int targetId )
        {
            var character = ValidatePlayerAndGetActiveCharacter(player, action);
        }

        private void DoUntargetedAction(Player player, Actions action)
        {
            var character =  ValidatePlayerAndGetActiveCharacter(player, action);
        }

        private Character ValidatePlayerAndGetActiveCharacter(Player player, Actions action)
        {
            if (!player.Characters.Any())
            {
                throw new GameException("No playable characters found");
            }

            var character = player.Characters.FirstOrDefault(x => !x.AllreadyMadeMove);

            if (character is null)
            {
                throw new GameException("All characters allready made moves");
            }

            var isActionsValid = _actionsManager.ValidateAction(character.Name, action);

            if (!isActionsValid)
            {
                throw new GameException("Move is not Valid for this Character");
            }

            return character;
        }
    }
}
