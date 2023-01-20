namespace PAM.Endpoints.Games;

public class GameGetAll
{
    public static string Template => "/games";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ApplicationDbContext context)
    {
        var search = context.Games.ToList();

        return Results.Ok(search);
    }
}
