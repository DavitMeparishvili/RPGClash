using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public interface ICharacter : IAttackerBehavior, IRegeneratorBehavior
{
    public CharacterName Name { get; }

    public int MaxHealth { get; }

    public int MaxMana { get; }

    public int CurrentHealth { get; set; }

    public ICharacter Target { get; set; }
}
