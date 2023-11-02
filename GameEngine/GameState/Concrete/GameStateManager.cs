using RPGClash.Domain.Characters;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using RPGClash.GameEngine.Game.Abstract;
using RPGClash.Infrastucture.Persistance;
using System.Text;

namespace RPGClash.GameEngine.Game.Concrete
{
    public class GameStateManager : IGameStateManager
    {
        private readonly IUserRepo _userRepo;

        private readonly ICharacterRepo _characterRepo;

        private readonly IGameStorageService _gameStorage;

        public GameStateManager(IUserRepo userRepo, ICharacterRepo characterRepo, IGameStorageService gameStorage)
        {
            _userRepo = userRepo;
            _characterRepo = characterRepo;
            _gameStorage = gameStorage;
        }

        public async Task<GameState> InitiateGameAsync(List<GameStateDto> gameState)
        {
            ValidateGameState(gameState);

            var (player1User, player1Characters) = await GetPlayerInfoAsync(gameState[0]);
            var (player2User, player2Characters) = await GetPlayerInfoAsync(gameState[1]);

            var state = new GameState()
            {
                Id = Guid.NewGuid().ToString(),
                Round = 0,
                Player1 = InitPlayerState(player1User, player1Characters),
                Player2 = InitPlayerState(player2User, player2Characters)
            };

            await _gameStorage.SetValue(state.Id, state);

            return state;
        }

        public async Task<GameState> GetGameStateAsync(string gameStateId)
        {
            return await _gameStorage.GetValue<GameState>(gameStateId);
        }

        private PlayerState InitPlayerState(User playerUser, List<Character> playerCharacters)
        {
            return new PlayerState()
            {
                UserId = playerUser.Id,
                DoneWithMoves = false,
                CharacterStates = playerCharacters.Select(c => new CharacterState(c)).ToList()
            };
        }

        private void ValidateGameState(List<GameStateDto> gameState)
        {
            if (gameState == null)
            {
                throw new GameException("Players not defined");
            }

            if (gameState.Count != 2)
            {
                throw new GameException("Only 2 player games are supported");
            }

            if (gameState.Any(x => x.Characters.Count != 3))
            {
                throw new GameException("Each player should pick 3 heroes");
            }

            if (gameState.Any(x => x.Characters.Distinct().Count() != x.Characters.Count))
            {
                throw new GameException("Each player should pick 3 different heroes");
            }
        }

        private async Task<(User playerUser, List<Character> playerCharacters)> GetPlayerInfoAsync(GameStateDto gameState)
        {
            var playerUser = await _userRepo.GetUserAsync(gameState.UserId);
            if (playerUser == null)
            {
                throw new GameException($"Player with ID {gameState.UserId} was not found");
            }

            var playerCharacters = await _characterRepo.GetCharactersAsync(gameState.Characters);
            if (playerCharacters.Count != 3)
            {
                throw new GameException("Player has selected an invalid number of characters");
            }

            return (playerUser, playerCharacters);
        }
    }
}
