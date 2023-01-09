namespace PAM.Endpoints.Books
{
    public record BookRequest(string Author, string BookName, string Publisher, int Pages, DateTime ReleaseDate, string Genre, string Country);
}
