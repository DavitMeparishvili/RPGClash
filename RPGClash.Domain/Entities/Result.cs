using RPGClash.Domain.Enums;

namespace RPGClash.Domain.Entities
{
    public class Result
    {
        public int Id { get; set; }

        public MatchStatus State { get; set; }

        public GameState GameState { get; set; } = default!;

        public int GameStateId { get; set; }

        public PlayerState Winner { get; set; }

        public int WinnerId { get; set; }
    }
}
