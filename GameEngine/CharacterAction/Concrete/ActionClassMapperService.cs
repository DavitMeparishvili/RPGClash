using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.CharacterClasses;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction.Abstract;

namespace RPGClash.GameEngine.CharacterAction.Concrete
{
    public class ActionClassMapperService : IActionClassMapperService
    {
        public List<Actions> GetCharacterActions(Character character)
        {
            Type characterType = character.GetType();
            var actions = new List<Actions>() { Actions.BasicAttack, Actions.Regenerate };

            if (typeof(IHealer).IsAssignableFrom(characterType))
            {
                actions.Add(Actions.Heal);
            }

            if (typeof(IHunter).IsAssignableFrom(characterType))
            {
                actions.Add(Actions.Shoot);
            }

            if (typeof(ITank).IsAssignableFrom(characterType))
            {
                actions.Add(Actions.Taunt);
            }

            return actions;
        }
    }
}
