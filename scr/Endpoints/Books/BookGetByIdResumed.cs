namespace PAM.Endpoints.Books;

public class BookGetByIdResumed
{
    public static string Template => "/books/resumed/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        var result = new BookResponse 
        { 
            Author = search.Author, 
            Title = search.Name, 
            Publisher = search.Publisher 
        };

        return Results.Ok(result);
    }
}