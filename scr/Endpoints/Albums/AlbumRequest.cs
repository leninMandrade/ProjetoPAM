namespace PAM.Endpoints.Albums
{
    public record AlbumRequest(string Artist, string AlbumName, int TracksNumbers, TimeSpan Lenght, DateTime ReleaseDate, string Genre, string Country);
}
