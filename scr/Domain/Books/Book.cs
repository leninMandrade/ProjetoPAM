namespace PAM.Domain.Books
{
    public class Book : Entity
    {
        public int Pages { get; set; }

        public Book()
        {
        }

        public Book(string writer, string bookName, int pageNumbers, DateTime releaseDate, string genre, string country)
        {
            Author = writer;
            Name = bookName;
            Pages = pageNumbers;
            ReleaseDate = releaseDate;
            Genre = genre;
            Country = country;
        }
    }
}
