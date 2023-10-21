using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Characters;

public class Guladi : Character, ITank
{
    public Guladi() : base(CharacterName.Guladi, 1800, 300) { }

    public void Taunt(Character traget)
    {
        MakeMove(x => x.IsTaunted = true, traget, 35);
    }
}