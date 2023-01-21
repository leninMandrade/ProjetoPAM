namespace PAM.Endpoints.Albums;

public class AlbumPost
{
    public static string Template => "/albums";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(AlbumRequest albumRequest, ApplicationDbContext context)
    {
        if (string.IsNullOrEmpty(albumRequest.Artist) || string.IsNullOrWhiteSpace(albumRequest.Artist) || albumRequest.Artist.Length < 3)
        {
            return Results.BadRequest("Informe um artista válido.");
        }
        if (string.IsNullOrEmpty(albumRequest.AlbumName) || string.IsNullOrWhiteSpace(albumRequest.AlbumName) || albumRequest.AlbumName.Length < 3)
        {
            return Results.BadRequest("Informe um album válido.");
        }
        if (albumRequest.TracksNumbers <= 0)
        {
            return Results.BadRequest("Informe uma quantidade válida de faixas.");
        }

        var album = new Album
        {
            Author = albumRequest.Artist,
            Name = albumRequest.AlbumName,
            Tracks = albumRequest.TracksNumbers,
            Lenght = albumRequest.Lenght,
            ReleaseDate = DateTime.Now,
            Genre = albumRequest.Genre,
            Country = albumRequest.Country
        };

        await context.Albums.AddAsync(album);
        await context.SaveChangesAsync();

        return Results.Created($"/albums/{album.Id}", album.Id);
    }
}
