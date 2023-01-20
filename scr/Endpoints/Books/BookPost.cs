namespace PAM.Endpoints.Books
{
    public class BookPost
    {
        public static string Template => "/books";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(BookRequest bookRequest, ApplicationDbContext context)
        {
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

            context.Books.Add(book);
            await context.SaveChangesAsync();

            return Results.Created($"/books/{book.Id}", book.Id);
        }
    }
}
