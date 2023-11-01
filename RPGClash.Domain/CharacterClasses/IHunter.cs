using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterClasses;

public interface IHunter
{
    Character Shoot(Character traget);
}