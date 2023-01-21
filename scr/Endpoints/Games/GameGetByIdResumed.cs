namespace PAM.Endpoints.Games;

public class GameGetByIdResumed
{
    public static string Template => "/games/resumed/{Id:Guid}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        var result = new GameResponse 
        { 
            Name = search.Name, 
            Developer = search.Author, 
            Genre= search.Genre 
        };

        return Results.Ok(result);
    }
}
