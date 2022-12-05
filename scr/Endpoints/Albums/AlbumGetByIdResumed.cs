using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumGetByIdResumed
{
    public static string Template => "/albums/resumed/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Albums.Where(x => x.Id == Id).FirstOrDefault();
        var result = new AlbumResponse { Author = search.Author, Name = search.Name, Genre = search.Genre };

        return Results.Ok(result);
    }
}
