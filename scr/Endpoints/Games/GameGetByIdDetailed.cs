using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Games;

public class GameGetByIdDetailed
{
    public static string Template => "/games/{Id}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id,  ApplicationDbContext context)
    {
        var search = context.Games.FirstOrDefault(x => x.Id == Id);

        return Results.Ok(search);
    }
}
