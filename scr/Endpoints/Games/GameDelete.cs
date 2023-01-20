namespace PAM.Endpoints.Games;

public class GameDelete
{
    public static string Template => "/games/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);

        context.Games.Remove(search);
        await context.SaveChangesAsync();

        return Results.Accepted();
    }
}
