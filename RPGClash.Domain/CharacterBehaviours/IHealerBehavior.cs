using RPGClash.Domain.Characters;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHealerBehavior
{
    ICharacter Heal(ICharacter traget);
}

