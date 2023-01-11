namespace PAM.Domain.Games;

public class Game : Entity
{
    // author as Developer
    public string Publisher { get; set; }
    public bool Multiplayer { get; set; }
    public string Platform { get; set; }

    public Game()
    {

    }

    public Game(string name, string developer, string publisher, string platform, string genre, DateTime releasedate, string country)
    {
        Name = name;
        Author = developer;
        Publisher = publisher;
        Platform = platform;
        Genre = genre;
        Multiplayer = false;
        ReleaseDate= releasedate;
        Country = country;
    }
}
