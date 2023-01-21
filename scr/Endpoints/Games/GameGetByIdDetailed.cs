namespace PAM.Endpoints.Games;

public class GameGetByIdDetailed
{
    public static string Template => "/games/{Id:Guid}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id,  ApplicationDbContext context)
    {
        var search = await context.Games.FirstOrDefaultAsync(x => x.Id == Id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        return Results.Ok(search);
    }
}
