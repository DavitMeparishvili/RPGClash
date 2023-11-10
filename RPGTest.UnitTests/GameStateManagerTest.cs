using FluentAssertions;
using NSubstitute;
using RPGClash.Domain.Characters;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using RPGClash.GameEngine.Game.Abstract;
using RPGClash.GameEngine.Game.Concrete;

namespace RPGClash.UnitTests
{
    public class GameStateManagerTest
    {
        private readonly IGameStateManager _SUTgameStateManager;

        private readonly IUserRepo _userRepo;

        private readonly ICharacterRepo _characterRepo;

        private readonly IGameStateRepo _gameStateRepo;

        public GameStateManagerTest()
        {
            _characterRepo = Substitute.For<ICharacterRepo>();
            _userRepo = Substitute.For<IUserRepo>();
            _gameStateRepo = Substitute.For<IGameStateRepo>();

            _SUTgameStateManager = new GameStateManager(_userRepo, _characterRepo, _gameStateRepo);
        }

        [Fact]
        public async Task InitiateGameAsync_ShouldRejectEmptyDto()
        {
            // Arrange
            Func<Task> act = () => _SUTgameStateManager.InitiateGameAsync(null);

            // Act and Assert
            await act.Should().ThrowAsync<GameException>().WithMessage("Players not defined");
        }

        [Fact]
        public async Task InitiateGameAsync_ShouldRejectNot2PLayers()
        {
            // Arrange
            var args = new List<GameStateDto>() { new GameStateDto() };
            Func<Task> act = () => _SUTgameStateManager.InitiateGameAsync(args);

            // Act and Assert
            await act.Should().ThrowAsync<GameException>().WithMessage("Only 2 player games are supported");
        }

        [Fact]
        public async Task InitiateGameAsync_ShouldRejectWhenPlayerDoesNotHave3Characters()
        {
            // Arrange
            var args = new List<GameStateDto>() 
            { 
                new GameStateDto() 
                { 
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva }
                },
                new GameStateDto()
                {
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva, CharacterName.Lucia }
                }
            };
            Func<Task> act = () => _SUTgameStateManager.InitiateGameAsync(args);

            // Act and Assert
            await act.Should().ThrowAsync<GameException>().WithMessage("Each player should pick 3 heroes");
        }

        [Fact]
        public async Task InitiateGameAsync_ShouldRejectWhenPlayerDoesNotHave3DifferentCharacters()
        {
            // Arrange
            var args = new List<GameStateDto>()
            {
                new GameStateDto()
                {
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva, CharacterName.Zezva }
                },
                new GameStateDto()
                {
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva, CharacterName.Lucia }
                }
            };
            Func<Task> act = () => _SUTgameStateManager.InitiateGameAsync(args);

            // Act and Assert
            await act.Should().ThrowAsync<GameException>().WithMessage("Each player should pick 3 different heroes");
        }

        [Fact]
        public async Task InitiateGameAsync_ShouldRejectUnexistingUser()
        {
            //Arreng
            var userId = "66152325";
            _userRepo.GetUserAsync(userId).ReturnsForAnyArgs((User)null);

            //Act
            var args = new List<GameStateDto>()
            {
                new GameStateDto()
                {
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva, CharacterName.Cedrick },
                    UserId = userId
                },
                new GameStateDto()
                {
                    Characters = new List<CharacterName>(){ CharacterName.Guladi, CharacterName.Zezva, CharacterName.Lucia }
                }
            };
            Func<Task> act = () => _SUTgameStateManager.InitiateGameAsync(args);

            // Act and Assert
            await act.Should().ThrowAsync<GameException>().WithMessage($"Player with ID {userId} was not found");
        }
    }
}
