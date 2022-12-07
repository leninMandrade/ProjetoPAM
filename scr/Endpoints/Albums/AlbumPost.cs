using PAM.Domain.Albums;
using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumPost
{
    public static string Template => "/albums";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AlbumRequest albumRequest, ApplicationDbContext context)
    {
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

        context.Albums.Add(album);
        context.SaveChanges();

        return Results.Created($"/categories/{album.Id}", album.Id);
    }
}
