using RPGClash.Domain.Classes;

namespace RPGClash.Domain.CharacterBehaviours;

public interface ITaunterBehavior
{
    ICharacter Taunt(ICharacter traget);
}
