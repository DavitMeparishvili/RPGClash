namespace RPGClash.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public List<User>? Friends { get; set; }
}
