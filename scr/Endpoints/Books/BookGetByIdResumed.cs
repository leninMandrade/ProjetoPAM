using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM.Infra.Data;

namespace PAM.Endpoints.Books;

public class BookGetByIdResumed
{
    public static string Template => "/books/resumed/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Books.Where(x => x.Id == Id).FirstOrDefault();
        var result = new BookResponse { Author = search.Author, Title = search.Name, Publisher = search.Publisher };

        return Results.Ok(result);
    }
}