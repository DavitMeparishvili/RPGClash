namespace RPGClash.Domain.Entities;

public class PlayerState
{
    public int Id { get; set; }
    public User User { get; set; } = default!;
    public int UserId { get; set; } = default!;
    public List<CharacterState> CharacterStates { get; set; } = default!;
    public int Round { get; set; } = default!;
    public bool MadeMove { get; set; }
}