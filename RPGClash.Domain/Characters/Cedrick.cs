using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Cedrick : Character, IHealer, IHunter
{
    public Cedrick() : base(CharacterName.Cedrick, 700, 600) {}

    public Character Heal(Character traget)
    {
        traget.CurrentHealth = +200;
        return traget;
    }

    public Character Shoot(Character traget)
    {
        traget.CurrentHealth = -220;
        return traget;
    }
}