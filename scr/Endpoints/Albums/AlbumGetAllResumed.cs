using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumGetAllResumed
{
    public static string Template => "/albums/resumed";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var results = context.Albums.ToList();
        var response = results.Select(p => new AlbumResponse { Author = p.Author, Name = p.Name, Genre = p.Genre });

        return Results.Ok(response);
    }
}
