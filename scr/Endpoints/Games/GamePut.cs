namespace PAM.Endpoints.Games;

public class GamePut
{
    public static string Template => "/games/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, GameRequest request, ApplicationDbContext context)
    {
        var search = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);

        search.Name = request.Name;
        search.Author = request.Developer;
        search.Publisher = request.Publisher;
        search.Platform = request.Platform;
        search.Genre = request.Genre;
        search.Multiplayer = request.Multiplayer;
        search.ReleaseDate = DateTime.Now;
        search.Country = request.Country;


        await context.SaveChangesAsync();

        return Results.Accepted();
    }
}
