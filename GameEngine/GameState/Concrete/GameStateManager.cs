using Microsoft.EntityFrameworkCore;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Enums;
using RPGClash.Domain.Repositories;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using RPGClash.GameEngine.Game.Abstract;

namespace RPGClash.GameEngine.Game.Concrete
{
    public class GameStateManager : IGameStateManager
    {
        private readonly IUserRepo _userRepo;

        private readonly ICharacterRepo _characterRepo;

        private readonly IGameStateRepo _gameStateRepo;

        private readonly Func<IQueryable<GameState>, IQueryable<GameState>> _deepIncludes = q =>
            q.Include(gs => gs.Player1)
            .Include(gs => gs.Player2)
            .Include(gs => gs.Winner);

        public GameStateManager(IUserRepo userRepo, ICharacterRepo characterRepo, IGameStateRepo gameStateRepo)
        {
            _userRepo = userRepo;
            _characterRepo = characterRepo;
            _gameStateRepo = gameStateRepo;
        }

        public async Task<GameState> InitiateGameAsync(List<GameStateDto> gameState)
        {
            ValidateGameState(gameState);

            var (player1User, player1Characters) = await GetPlayerInfoAsync(gameState[0]);
            var (player2User, player2Characters) = await GetPlayerInfoAsync(gameState[1]);

            var entity = new GameState()
            {
                Round = 0,
                Player1 = InitPlayerState(player1User, player1Characters),
                Player2 = InitPlayerState(player2User, player2Characters),
                State = MatchStatus.Ongoing
            };

            await _gameStateRepo.AddGameStateAsync(entity);

            return entity;
        }

        public async Task<GameState> GetGameStateAsync(int gameStateId)
        {
            var gameState = await _gameStateRepo.GetGameStateAsync(gameStateId, _deepIncludes);
            
            if (gameState == null)
            {
                throw new GameException("Current game could not be found");
            }

            return gameState;
        }

        public async Task<GameState> FinishGameAsync(int gameStateId, string winnerUserId)
        {
            var gameState = await _gameStateRepo.GetGameStateAsync(gameStateId, _deepIncludes);

            if (gameState == null)
            {
                throw new GameException("Current game could not be found");
            }

            gameState.State = MatchStatus.Finished;

            var playerUser = await _userRepo.GetUserAsync(winnerUserId);
            
            if (playerUser == null)
            {
                throw new GameException($"Player with ID {winnerUserId} was not found");
            }

            gameState.IsFinished = true;
            gameState.WinnerId = winnerUserId;

            return gameState;
        }

        private Player InitPlayerState(User playerUser, List<DbCharacter> playerCharacters)
        {
            return new Player()
            {
                UserId = playerUser.Id,
                DoneWithMoves = false,
                Characters = playerCharacters
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

        private async Task<(User playerUser, List<DbCharacter> playerCharacters)> GetPlayerInfoAsync(GameStateDto gameState)
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
