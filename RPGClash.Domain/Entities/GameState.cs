namespace RPGClash.Domain.Entities
{
    public class GameState
    {
        public string Id { get; set; }

        public PlayerState Player1 { get; set; } = default!;

        public PlayerState Player2 { get; set; } = default!;

        public int Round { get; set; } = default!;
    }
}
