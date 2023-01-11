using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Games;

public class GameGetByIdResumed
{
    public static string Template => "/games/resumed/{Id}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Games.FirstOrDefault(x => x.Id == Id);

        var result = new GameResponse 
        { 
            Name = search.Name, 
            Developer = search.Author, 
            Genre= search.Genre 
        };

        return Results.Ok(result);
    }
}
