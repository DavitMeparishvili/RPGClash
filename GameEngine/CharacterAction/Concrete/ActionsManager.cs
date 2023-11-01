using RPGClash.Domain;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction.Abstract;
using RPGClash.GameEngine.Dtos;
using RPGClash.GameEngine.Exceptions;
using System.Reflection;

namespace RPGClash.GameEngine.CharacterAction.Concrete
{
    public class ActionsManager : IActionsManager
    {
        private List<CharacterWithActions> _charactersWithActions = new List<CharacterWithActions>();
        
        private readonly IActionClassMapperService _actionClassMapperService;

        public ActionsManager(IActionClassMapperService actionClassMapperService)
        {
            _actionClassMapperService = actionClassMapperService;
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
            var character = CreateCharacter(characterName);

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

        //To Be factory service
        private Character CreateCharacter(CharacterName character)
        {
            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var domainAssemblies = loadedAssemblies
                .Where(assembly => assembly == typeof(AssamblyReference).Assembly)
                .ToList();

            // Iterate through the assemblies and types to find a suitable type
            foreach (var assembly in domainAssemblies)
            {
                var characterType = assembly.GetTypes()
                    .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Character)))
                    .FirstOrDefault(t =>
                    {
                        var nameProperty = t.GetProperty("Name");
                        if (nameProperty != null)
                        {
                            var defaultValue = nameProperty.GetValue(Activator.CreateInstance(t));
                            return defaultValue?.ToString() == character.ToString();
                        }
                        return false;
                    });

                if (characterType != null)
                {
                    // Create an instance of the found type
                    return (Character)Activator.CreateInstance(characterType);
                }
            }

            // If no suitable type is found, return null or handle the case accordingly.
            return null;
        }
    }
}
