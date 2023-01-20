namespace PAM.Endpoints.Albums;

public class AlbumDelete
{
    public static string Template => "/albums/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var search = await context.Albums.FirstOrDefaultAsync(x => x.Id == id);

        context.Albums.Remove(search);
        await context.SaveChangesAsync();
        return Results.Ok();
    }
}
