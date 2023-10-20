using RPGClash.Domain.Classes;

namespace RPGClash.Domain.Entities;

public class CharacterState
{
    public int Id { get; set; }

    public int PlayerStateId { get; set; }

    public PlayerState PlayerState { get; set; } = default!;

    public int CurrentHealth { get; set; } = default!;

    public int CurrentMana { get; set; } = default!;

    public ICharacter Character { get; set; } = default!;

    public bool ALeadyPlayed { get; set; } = false;

    public int TargetedCharacterId { get; set; }

    public CharacterState? TargetedCharacted { get; set; }
}
