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

    public int BasicHeatPoint { get; set; }

    public int BasicHealPoint { get; set; }

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

    public Character(CharacterName name, int maxHealth, int maxMana, int basicHeatPoint, int hasicHealPoint)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxMana = maxMana;
        CurrentMana = maxMana;
        CurrentHealth = maxHealth;
        BasicHeatPoint = basicHeatPoint;
        BasicHealPoint = hasicHealPoint;
    }

    public virtual Character BasicAttack(Character traget)
    {
        MakeMove(x => x.CurrentHealth -= BasicHeatPoint, traget, 0);
        return traget;
    }

    public virtual void Regenerate()
    {
        if (ValidateMove(60))
        {
            CurrentHealth += BasicHealPoint;
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

    protected virtual bool MakeMove(Action<Character> move, Character target, int manaCost)
    {
        return MakeMove(move, new List<Character> { target }, manaCost);
    }

    protected virtual bool MakeMove(Action<Character> move, List<Character> targets, int manaCost)
    {
        if (ValidateMove(manaCost))
        {
            foreach (var target in targets)
            {
                target.CurrentMana -= manaCost;
                move(target);
                UpdateCharacterStatus(target);
            }
            return true;
        }

        return false;
    }
}
