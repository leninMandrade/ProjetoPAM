using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumGetAllResumed
{
    public static string Template => "/albums/resumed";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var search = context.Albums.ToList();
        var result = search.Select(x => new AlbumResponse 
        { 
            Author = x.Author, 
            Name = x.Name, 
            Genre = x.Genre
        });

        return Results.Ok(result);
    }
}
