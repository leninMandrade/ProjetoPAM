using PAM.Infra.Data;

namespace PAM.Endpoints.Books;

public class BookGetAllResumed
{
    public static string Template => "/books/resumed";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var search = context.Books.ToList();
        var result = search.Select(x => new BookResponse {Author = x.Author, Title = x.Name, Publisher = x.Publisher }).ToList();

        return Results.Ok(result);
    }
}
