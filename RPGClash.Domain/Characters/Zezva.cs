using RPGClash.Domain.CharacterClasses;

namespace RPGClash.Domain.Characters;

public class Zezva : Character, ITank, IHunter
{
    public Zezva() : base(CharacterName.Zezva, 1500, 400, 140, 50) { }

    public Character Shoot(Character traget)
    {
        MakeMove(x => x.CurrentHealth -= 200, traget, 30);
        return traget;
    }

    public void Taunt(Character traget)
    {
        MakeMove(x => x.TauntedTarget = this, traget, 30);
    }
}