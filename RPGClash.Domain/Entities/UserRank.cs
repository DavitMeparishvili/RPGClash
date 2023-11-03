using RPGClash.Domain.Enums;

namespace RPGClash.Domain.Entities
{
    public class UserRank
    {
        public int Id { get; set; }

        public Ranks Rank { get; set; }

        public List<User> Users { get; set; }
    }
}
