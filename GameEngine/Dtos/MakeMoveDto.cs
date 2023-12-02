using RPGClash.Domain.CharacterAction;

namespace RPGClash.GameEngine.Dtos
{
    public class MakeMoveDto
    {
        public int GameStateId { get; set; }

        public int CharacterId { get; set; }

        public Actions Actions { get; set; }

        public string UserId { get; set; }
    }
}
