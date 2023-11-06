using RPGClash.Domain.Enums;

namespace RPGClash.Domain.Entities
{
    public class GameState
    {
        public string Id { get; set; }

        public int Player1Id { get; set; } = default!;

        public Player Player1 { get; set; } = default!;

        public int Player2Id { get; set; } = default!;

        public Player Player2 { get; set; } = default!;

        public int Round { get; set; } = default!;

        public MatchStatus State { get; set; }

        public User? Winner { get; set; }

        public int? WinnerId { get; set; }

        public bool IsFinished { get; set; }
    }
}
