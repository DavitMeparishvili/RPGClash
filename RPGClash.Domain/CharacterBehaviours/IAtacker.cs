using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IAttacker
{
    Character BasicAttack(Character traget);
}
