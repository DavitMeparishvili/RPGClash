using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Lucia : Character, IHealer
{
    public Lucia() : base(CharacterName.Lucia, 600, 800) { }

    public Character Heal(Character traget)
    {
        traget.CurrentHealth = +300;
        return traget;
    }
}
