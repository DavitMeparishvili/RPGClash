using RPGClash.Domain.CharacterClasses;

namespace RPGClash.Domain.Characters;

public class Guladi : Character, ITank
{
    public Guladi() : base(CharacterName.Guladi, 1800, 300, 90, 70) { }

    public void Taunt(Character traget)
    {
        MakeMove(x => x.TauntedTarget = this, traget, 35);
    }
}