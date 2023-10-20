using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHunterBehavior
{
    ICharacter Shoot(ICharacter traget);
}