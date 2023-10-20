using RPGClash.Domain.CharacterBehaviours;
using RPGClash.Domain.Characters;

namespace RPGClash.Domain.Classes;

public interface ICharacter : IAttackerBehavior, IRegeneratorBehavior
{
    public CharacterName Name { get; }

    public int MaxHealth { get;}

    public int MaxMana { get;}

    public int CurrentHealth { get; set; }

    public ICharacter Target { get; set; }
}
