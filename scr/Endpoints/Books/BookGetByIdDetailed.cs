using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM.Infra.Data;

namespace PAM.Endpoints.Books;

public class BookGetByIdDetailed
{
    public static string Template => "/books/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = context.Books.FirstOrDefault(x => x.Id == Id);

        return Results.Ok(search);
    }
}
