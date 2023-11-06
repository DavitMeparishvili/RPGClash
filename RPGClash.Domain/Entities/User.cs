using Microsoft.AspNetCore.Identity;

namespace RPGClash.Domain.Entities;
public class User : IdentityUser
{
    public string UserName { get; set; } = default!;
    public List<User>? Friends { get; set; }
    public int UserRankId { get; set; }
    public UserRank? UserRank { get; set; }
}
