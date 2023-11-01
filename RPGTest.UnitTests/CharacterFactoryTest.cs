using FluentAssertions;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.Factory.Abstract;
using RPGClash.GameEngine.Factory.Concrete;

namespace RPGClash.UnitTests
{
    public class CharacterFactoryTest
    {
        private readonly ICharacterFactory _characterFactory;
        
        public CharacterFactoryTest()
        {
            _characterFactory = new CharacterFactory();
        }

        [Theory]
        [InlineData(CharacterName.Cedrick)]
        [InlineData(CharacterName.Guladi)]
        [InlineData(CharacterName.Zezva)]
        [InlineData(CharacterName.Lucia)]
        public void Factory_CorrectCaracterIsCreated(CharacterName character)
        {
            // Arrange - Act
            var implementation = _characterFactory.CreateCharacter(character);

            //Assert
            implementation.Name.Should().Be(character);
        }
    }
}
