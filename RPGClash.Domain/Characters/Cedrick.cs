using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Cedrick : ICharacter, IHealerBehavior, IHunterBehavior
{
    public CharacterName Name => CharacterName.Cedrick;

    public ICharacter Target { get; set; }

    public int MaxHealth { get; }

    public int MaxMana { get; }

    public int CurrentHealth { get; set; }

    public Cedrick()
    {
        var maxHealth = 700;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = 700;
    }

    public ICharacter BasicAttack(ICharacter traget)
    {
        traget.CurrentHealth = -120;
        return traget;
    }

    public ICharacter Heal(ICharacter traget)
    {
        traget.CurrentHealth = +200;
        return traget;
    }

    public void Regenerate()
    {
        CurrentHealth = +170;
    }

    public ICharacter Shoot(ICharacter traget)
    {
        traget.CurrentHealth = -220;
        return traget;
    }
}