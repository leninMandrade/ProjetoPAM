﻿namespace PAM.Endpoints.Books;

public class BookDelete
{
    public static string Template => "/books/{Id:Guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Books.FirstOrDefaultAsync(x => x.Id == Id);

        if (search == null)
        {
            return Results.NotFound("O Id informado não existe.");
        }

        context.Books.Remove(search);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
