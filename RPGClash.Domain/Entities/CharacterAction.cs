using RPGClash.Domain.CharacterAction;

namespace RPGClash.Domain.Entities;
public class CharacterAction
{
    public int Id { get; set; }

    public Actions ActionKey { get; set; }
}