using RPGClash.Domain.CharacterClasses;

namespace RPGClash.Domain.Characters;

public class Cedrick : Character, IHealer, IHunter
{
    public Cedrick() : base(CharacterName.Cedrick, 700, 600, 150, 120) {}

    public Character Heal(Character target)
    {
        MakeMove(x => x.CurrentHealth += 200, target, 50);
        return target;
    }

    public Character Shoot(Character target)
    {
        var hitTarget = TauntValidateAndGetrealtarget(target);
        MakeMove(x => x.CurrentHealth -= 220, hitTarget, 50);
        return hitTarget;
    }
}