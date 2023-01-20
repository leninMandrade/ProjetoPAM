﻿namespace PAM.Endpoints.Albums;

public class AlbumGetByIdDetailed
{
    public static string Template => "/albums/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var search = await context.Albums.FirstOrDefaultAsync(x => x.Id == Id);
                
        return Results.Ok(search);
    }
}
