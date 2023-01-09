using PAM.Infra.Data;

namespace PAM.Endpoints.Books
{
    public class BookGetAll
    {
        public static string Template => "/books";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString(), };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var search = context.Books.ToList();

            return Results.Ok(search);
        }
    }
}
