using RPGClash.Domain.Characters;

namespace RPGClash.Domain.Entities
{
    public class PlayerCharacter : Character
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
