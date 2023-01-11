using PAM.Infra.Data;

namespace PAM.Endpoints.Games;

public class GameGetAllResumed
{
    public static string Template => "/games/resumed";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var search = context.Games.ToList();

        var result = search.Select(x => new GameResponse
        {
            Name = x.Name,
            Developer = x.Author,
            Genre = x.Genre
        });

        return Results.Ok(result);
    }
}
