using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterClasses;

public interface IAttacker
{
    Character BasicAttack(Character traget);
}
