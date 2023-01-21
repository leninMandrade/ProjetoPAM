namespace PAM.Endpoints.Albums;

public class AlbumPut
{
    public static string Template => "/albums/{Id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, AlbumRequest request, ApplicationDbContext context)
    {
        var search = await context.Albums.FirstOrDefaultAsync(x => x.Id == Id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        search.Author = request.Artist;
        search.Name = request.AlbumName;
        search.Tracks = request.TracksNumbers;
        search.Lenght = request.Lenght;        
        search.Genre = request.Genre;
        search.Country = request.Country;

        await context.SaveChangesAsync();

        return Results.Accepted();
    }
}
