namespace PAM.Endpoints.Games;

public class GameGetByIdDetailed
{
    public static string Template => "/games/{Id}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id,  ApplicationDbContext context)
    {
        var search = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);

        return Results.Ok(search);
    }
}
