namespace PAM.Endpoints.Books;

public class BookPut
{
    public static string Template => "/books/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, BookRequest bookRequest, ApplicationDbContext context)
    {
        var search = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        search.Author = bookRequest.Author;
        search.Name = bookRequest.BookName;
        search.Genre = bookRequest.Genre;
        search.Publisher = bookRequest.Publisher;
        search.Pages = bookRequest.Pages;
        search.ReleaseDate = DateTime.Now;
        search.Country = bookRequest.Country;

        await context.SaveChangesAsync();
        return Results.Accepted();
    }
}
