using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction.Abstract;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using RPGClash.GameEngine.Factory.Abstract;

namespace RPGClash.GameEngine.CharacterAction.Concrete
{
    public class ActionsManager : IActionsManager
    {
        private List<CharacterWithActions> _charactersWithActions = new List<CharacterWithActions>();
        
        private readonly IActionClassMapperService _actionClassMapperService;
        private readonly ICharacterFactory _characterFactory;

        public ActionsManager(IActionClassMapperService actionClassMapperService, ICharacterFactory characterFactory)
        {
            _actionClassMapperService = actionClassMapperService;
            _characterFactory = characterFactory;
        }

        public CharacterWithActions GetAvailableActions(CharacterName character)
        {
            var characterWithActions = _charactersWithActions.FirstOrDefault(x => x.CharacterName == character);

            if (characterWithActions is null) 
            {
                characterWithActions = CreateCharacterWithActions(character);

                if (characterWithActions is null)
                {
                    throw new GameException("Character cannot be instantiated");
                }

                _charactersWithActions.Add(characterWithActions);

                return characterWithActions;
            }
            
            return characterWithActions;
        }

        private CharacterWithActions CreateCharacterWithActions(CharacterName characterName) 
        {
            var character = _characterFactory.CreateCharacter(characterName);

            if (character is not null)
            {
                var actions = _actionClassMapperService.GetCharacterActions(character);

                return new CharacterWithActions()
                {
                    CharacterName = characterName,
                    Actions = actions,
                    Character = character
                };
            }
            else
            {
                return null;
            }
        }
    }
}
