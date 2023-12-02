using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction.Models;

namespace RPGClash.GameEngine.CharacterAction.Abstract
{
    public interface IActionsManager
    {
        public CharacterWithActions GetAvailableActions(CharacterName character);

        public bool ValidateAction(CharacterName character, Actions action);
    }
}
