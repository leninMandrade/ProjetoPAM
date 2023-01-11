using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Albums;

public class AlbumGetByIdDetailed
{
    public static string Template => "/albums/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Albums.FirstOrDefault(x => x.Id == Id);
                
        return Results.Ok(search);
    }
}
