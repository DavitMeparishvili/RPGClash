using RPGClash.Domain.CharacterClasses;
using RPGClash.Domain.Entities;

namespace RPGClash.Domain.Characters;

public abstract class Character : IAttacker, IRegenerator
{
    public CharacterName Name { get; }

    public int MaxHealth { get; }

    public int MaxMana { get; }

    public int CurrentHealth { get; set; }

    public int CurrentMana { get; set; }

    public bool IsTaunted { get; set; }

    public bool IsAlive { get; private set; } = true;

    public int BasicHeatPoint { get; set; }

    public int BasicHealingPoint { get; set; }

    private Character _tauntedTarget;

    public Character TauntedTarget
    {
        get => _tauntedTarget;
        set
        {
            if(!IsTaunted)
            {
                IsTaunted = true;
                _tauntedTarget = value;
            }
        }
    }

    public bool AllreadyMadeMove { get; set; }

    public Character() {}

    public Character(CharacterName name, int maxHealth, int maxMana, int basicHeatPoint, int hasicHealPoint)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
        CurrentMana = maxMana;
        CurrentHealth = maxHealth;
        BasicHeatPoint = basicHeatPoint;
        BasicHealingPoint = hasicHealPoint;
    }

    public virtual Character BasicAttack(Character target)
    {
        var hitTarget = TauntValidateAndGetrealtarget(target);
        MakeMove(x => x.CurrentHealth -= BasicHeatPoint, hitTarget, 0);
        return hitTarget;
    }

    protected Character TauntValidateAndGetrealtarget(Character target)
    {
        if (IsTaunted)
        {
            IsTaunted = false;
            return TauntedTarget;
        }
        else
        {
            return target;
        }
    }

    public virtual void Regenerate()
    {
        MakeMove(x => x.CurrentHealth += BasicHealingPoint, this, 60);
    }

    protected bool ValidateAndDeductManaCost(int manaCost)
    {
        if (manaCost > CurrentMana)
        {
           return false;
        }
        else
        {
            CurrentMana -= manaCost;
            return true;
        }
    }

    private void UpdateCharacterStatus(Character character)
    {
        if (character.CurrentHealth <= 0)
        {
            character.CurrentHealth = 0;
            character.IsAlive = false;
        }
    }

    private void CheckForOverHeal(Character character)
    {
        if (character.CurrentHealth > character.MaxHealth) 
        {
            character.CurrentHealth = character.MaxHealth;
        }
    }

    protected virtual bool MakeMove(Action<Character> move, Character target, int manaCost)
    {
        return MakeMove(move, new List<Character> { target }, manaCost);
    }

    protected virtual bool MakeMove(Action<Character> move, List<Character> targets, int manaCost)
    {
        if (ValidateAndDeductManaCost(manaCost))
        {
            AllreadyMadeMove = true;
            foreach (var target in targets)
            {
                move(target);
                UpdateCharacterStatus(target);
                CheckForOverHeal(target);
            }
            return true;
        }

        return false;
    }
}
