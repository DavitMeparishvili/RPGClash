using System.Reflection.Metadata.Ecma335;

namespace RPGClash.Domain.Entities;
public class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public CharacterClass Class { get; set; } = default!;

    public List<CharacterMove> Moves { get; set; } = default!;

    public int MaxHealth { get; set; } = default!;

    public int MaxMana { get; set; } = default!;
}
