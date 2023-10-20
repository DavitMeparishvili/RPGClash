using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface ITank
{
    Character Taunt(Character traget);
}
