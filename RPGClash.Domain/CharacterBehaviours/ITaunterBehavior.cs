using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface ITaunterBehavior
{
    ICharacter Taunt(ICharacter traget);
}
