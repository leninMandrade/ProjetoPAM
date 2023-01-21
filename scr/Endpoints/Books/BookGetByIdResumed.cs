namespace PAM.Endpoints.Books;

public class BookGetByIdResumed
{
    public static string Template => "/books/resumed/{Id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        var result = new BookResponse 
        { 
            Author = search.Author, 
            Title = search.Name, 
            Publisher = search.Publisher 
        };

        return Results.Ok(result);
    }
}