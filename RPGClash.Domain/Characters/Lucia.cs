using RPGClash.Domain.Classes;

namespace RPGClash.Domain.Characters;

public class Lucia : IHealer
{
    public CharacterName Name => CharacterName.Lucia;

    public ICharacter Target { get; set; }

    public int MaxHealth { get; }

    public int MaxMana { get; }

    public int CurrentHealth { get; set; }

    public Lucia()
    {
        var maxHealth = 800;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = 700;
    }

    public ICharacter BasicAttack(ICharacter traget)
    {
        traget.CurrentHealth = - 70;
        return traget;
    }

    public ICharacter Heal(ICharacter traget)
    {
        traget.CurrentHealth = +300;
        return traget;
    }

    public void Regenerate()
    {
        CurrentHealth = +370;
    }
}
