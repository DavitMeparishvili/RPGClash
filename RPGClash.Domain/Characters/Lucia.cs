using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Lucia : Character, IHealer
{
    public Lucia() : base(CharacterName.Lucia, 600, 800) { }

    public Character Heal(Character traget)
    {
        MakeMove(x => x.CurrentHealth = +300, traget, 40);
        return traget;
    }
}
