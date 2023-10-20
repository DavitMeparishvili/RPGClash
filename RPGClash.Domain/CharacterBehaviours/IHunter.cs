using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHunter
{
    Character Shoot(Character traget);
}