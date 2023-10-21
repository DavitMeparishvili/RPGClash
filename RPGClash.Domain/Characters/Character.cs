using RPGClash.Domain.CharacterBehaviours;

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

    private Character _target;

    public Character Target
    {
        get => _target;
        set
        {
            if(!IsTaunted)
            _target = value;
        }
    }

    public Character(CharacterName name, int maxHealth, int maxMana)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
        CurrentHealth = maxMana;
    }

    public virtual Character BasicAttack(Character traget)
    {
        MakeMove(x => x.CurrentHealth = -120, traget, 0);
        return traget;
    }

    public virtual void Regenerate()
    {
        if (ValidateMove(60))
        {
            CurrentHealth = +170;
        }
    }

    protected bool ValidateMove(int manaCost)
    {
        if (manaCost > CurrentMana)
        {
           return false;
        }
        else
        {
            CurrentMana = -manaCost;
            return true;
        }
    }

    protected virtual bool MakeMove(Action<Character> move, Character target, int manaCost) 
    { 
        if (ValidateMove(manaCost))
        {
           move(target);
           if(target.CurrentHealth <=0)
           {
                target.CurrentHealth = 0;
                target.IsAlive = false;
           }
           return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual bool MakeMassMove(Action<Character> move, List<Character> targets, int manaCost)
    {
        if (ValidateMove(manaCost))
        {
            foreach (var target in targets)
            {
                move(target);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
