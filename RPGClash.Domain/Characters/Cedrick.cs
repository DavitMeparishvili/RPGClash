using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Cedrick : Character, IHealer, IHunter
{
    public Cedrick() : base(CharacterName.Cedrick, 700, 600, 150, 120) {}

    public Character Heal(Character traget)
    {
        MakeMove(x => x.CurrentHealth += 200, traget, 50);
        return traget;
    }

    public Character Shoot(Character traget)
    {
        MakeMove(x => x.CurrentHealth -= 220, traget, 50);
        return traget;
    }
}