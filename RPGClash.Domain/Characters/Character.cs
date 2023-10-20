using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public abstract class Character : IAttacker, IRegenerator
{
    public CharacterName Name { get; }

    public int MaxHealth { get; }

    public int MaxMana { get; }

    public int CurrentHealth { get; set; }

    public Character Target { get; set; }

    public Character(CharacterName name, int maxHealth, int maxMana)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
    }

    public virtual Character BasicAttack(Character traget)
    {
        traget.CurrentHealth = -120;
        return traget;
    }

    public virtual void Regenerate()
    {
        CurrentHealth = +170;
    }

    public virtual void SetTarget(Character traget)
    {
        Target = traget;
    }
}
