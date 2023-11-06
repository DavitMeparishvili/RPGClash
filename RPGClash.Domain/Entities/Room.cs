namespace RPGClash.Domain.Entities;
public class Room
{
    public int Id { get; set; }

    public string Player1Id { get; set; }
    
    public User? Player1 { get; set; }

    public string Player2Id { get; set; }

    public User? Player2 { get; set; }

    public bool Vacant { get; set; } = true;

    public bool Finished { get; set; }
}
