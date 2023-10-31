using RPGClash.Domain.Characters;
using RPGClash.GameEngine.Dtos;

namespace RPGClash.GameEngine.CharacterAction.Abstract
{
    public interface IActionsManager
    {
        public CharacterWithActions GetAvailableActions(CharacterName character);
    }
}
