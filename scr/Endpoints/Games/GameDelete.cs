using Microsoft.AspNetCore.Mvc;
using PAM.Infra.Data;

namespace PAM.Endpoints.Games;

public class GameDelete
{
    public static string Template => "/games/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Games.FirstOrDefault(x => x.Id == Id);

        context.Games.Remove(search);
        context.SaveChanges();

        return Results.Accepted();
    }
}
