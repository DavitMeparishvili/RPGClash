namespace RPGClash.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public List<User>? Friends { get; set; }
    public int UserRankId { get; set; }
    public UserRank? UserRank { get; set; }
}
