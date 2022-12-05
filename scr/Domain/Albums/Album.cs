namespace PAM.Domain.Albums;

public class Album : Entity
{
    public int Tracks { get; set; }
    public TimeSpan Lenght { get; set; }

    public Album()
    {
    }

    public Album(string artist, string albumName, int tracks, TimeSpan lenght, DateTime releaseDate, string genre, string country)
    {
        Author = artist;
        Name = albumName;
        Tracks = tracks;
        Lenght = lenght;
        ReleaseDate = releaseDate;
        Genre = genre;
        Country = country;
    }
}
