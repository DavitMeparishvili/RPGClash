using FluentAssertions;
using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction;
using RPGClash.GameEngine.CharacterAction.Abstract;
using RPGClash.GameEngine.CharacterAction.Concrete;
using RPGClash.UnitTests.Shared;

namespace RPGClash.UnitTests
{
    public class ActionClassMapperServiceTest
    {
        private readonly IActionClassMapperService _actionClassMapperService;
        public ActionClassMapperServiceTest()
        {
            _actionClassMapperService = new ActionClassMapperService();
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterAllowedActionsData))]
        public void ActionsMapper_ShouldReturnCorrectAllowedResults(Character character, List<Actions> actions)
        {
            //Arrange - Act
            var sutResult = _actionClassMapperService.GetCharacterActions(character);

            //Assert
            sutResult.Should().BeEquivalentTo(actions);
        }
    }
}
