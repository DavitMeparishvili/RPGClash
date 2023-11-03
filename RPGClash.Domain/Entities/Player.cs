using RPGClash.Domain.Characters;

namespace RPGClash.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public User User { get; set; } = default!;
    public int UserId { get; set; } = default!;
    public List<Character> Characters { get; set; } = default!;
    public bool DoneWithMoves { get; set; }
}