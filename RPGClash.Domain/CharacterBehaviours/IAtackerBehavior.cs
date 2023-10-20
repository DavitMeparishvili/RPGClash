using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IAttackerBehavior
{
    ICharacter BasicAttack(ICharacter traget);
}
