using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHealer
{
    Character Heal(Character traget);
}

