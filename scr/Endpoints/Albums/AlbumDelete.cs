using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumDelete
{
    public static string Template => "/albums/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var search = context.Albums.FirstOrDefault(x => x.Id == id);

        context.Albums.Remove(search);
        context.SaveChanges();
        return Results.Ok();
    }
}
