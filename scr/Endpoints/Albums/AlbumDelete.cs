namespace PAM.Endpoints.Albums;

public class AlbumDelete
{
    public static string Template => "/albums/{Id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var search = await context.Albums.FirstOrDefaultAsync(x => x.Id == id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        context.Albums.Remove(search);
        await context.SaveChangesAsync();
        return Results.Ok();
    }
}
