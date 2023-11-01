using RPGClash.Domain.Characters;

namespace RPGClash.GameEngine.Factory.Abstract
{
    public interface ICharacterFactory
    {
        public Character CreateCharacter(CharacterName character);
    }
}
