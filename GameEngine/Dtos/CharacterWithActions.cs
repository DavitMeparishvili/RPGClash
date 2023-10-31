using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction;

namespace RPGClash.GameEngine.Dtos
{
    public class CharacterWithActions
    {
        public CharacterName CharacterName { get; set; }
        
        public List<Actions> Actions { get; set; }

        public Character Character { get; set; }
    }
}
