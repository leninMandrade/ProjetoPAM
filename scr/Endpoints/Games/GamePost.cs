﻿namespace PAM.Endpoints.Games;

public class GamePost
{
    public static string Template => "/games";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(GameRequest request, ApplicationDbContext context)
    {
        var game = new Game
        {
            Name = request.Name,
            Author = request.Developer,
            Publisher = request.Publisher,
            Platform = request.Platform,
            Genre = request.Genre,
            Multiplayer = request.Multiplayer,
            ReleaseDate = DateTime.Now,
            Country = request.Country
        };

        context.Games.Add(game);
        await context.SaveChangesAsync();

        return Results.Created($"/games/{game.Id}", game.Id);
    }    
}
