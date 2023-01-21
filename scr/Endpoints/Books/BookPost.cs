namespace PAM.Endpoints.Books;

public class BookPost
{
    public static string Template => "/books";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(BookRequest bookRequest, ApplicationDbContext context)
    {
        if (string.IsNullOrEmpty(bookRequest.Author) || string.IsNullOrWhiteSpace(bookRequest.Author) || bookRequest.Author.Length < 3)
        {
            return Results.BadRequest("Informe um autor válido.");
        }
        if (string.IsNullOrEmpty(bookRequest.BookName) || string.IsNullOrWhiteSpace(bookRequest.BookName) || bookRequest.BookName.Length < 3)
        {
            return Results.BadRequest("Informe um livro válido.");
        }
        if (bookRequest.Pages <= 0)
        {
            return Results.BadRequest("Informe uma quantidade válida de páginas.");
        }

        var book = new Book
        {
            Author = bookRequest.Author,
            Name = bookRequest.BookName,
            Genre = bookRequest.Genre,
            Publisher = bookRequest.Publisher,
            Pages = bookRequest.Pages,
            ReleaseDate = DateTime.Now,
            Country = bookRequest.Country
        };

        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();

        return Results.Created($"/books/{book.Id}", book.Id);
    }
}

