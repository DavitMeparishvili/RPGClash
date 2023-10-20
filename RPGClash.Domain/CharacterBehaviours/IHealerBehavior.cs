using RPGClash.Domain.Classes;

namespace RPGClash.Domain.CharacterBehaviours;

public interface IHealerBehavior
{
    ICharacter Heal(ICharacter traget);
}

