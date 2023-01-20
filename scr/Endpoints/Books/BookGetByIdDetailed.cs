namespace PAM.Endpoints.Books;

public class BookGetByIdDetailed
{
    public static string Template => "/books/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        return Results.Ok(search);
    }
}
