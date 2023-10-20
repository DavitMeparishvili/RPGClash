using RPGClash.Domain.Classes;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IAttackerBehavior
{
    ICharacter BasicAttack(ICharacter traget);
}
