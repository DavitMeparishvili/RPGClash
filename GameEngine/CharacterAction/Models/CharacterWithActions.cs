using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;

namespace RPGClash.GameEngine.CharacterAction.Models
{
    public class CharacterWithActions
    {
        public CharacterName CharacterName { get; set; }

        public List<Actions> Actions { get; set; }

        public Character Character { get; set; }
    }
}
