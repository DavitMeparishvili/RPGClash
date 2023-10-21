using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Gulari : Character, ITank
{
    public Gulari() : base(CharacterName.Guladi, 1800, 300) { }

    public Character Heal(Character traget)
    {
        MakeMove(x => x.CurrentHealth = +120, traget, 55);
        return traget;
    }

    public void Taunt(Character traget)
    {
        MakeMove(x => x.IsTaunted = true, traget, 35);
    }
}