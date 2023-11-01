using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterClasses;

public interface IHealer
{
    Character Heal(Character traget);
}

