using RPGClash.Domain.Classes;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHunterBehavior
{
    ICharacter Shoot(ICharacter traget);
}