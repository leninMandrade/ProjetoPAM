namespace PAM.Endpoints.Games;

public class GamePost
{
    public static string Template => "/games";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(GameRequest request, ApplicationDbContext context)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrWhiteSpace(request.Name) || request.Name.Length < 3)
        {
            return Results.BadRequest("Informe um jogo válido.");
        }
        if (string.IsNullOrEmpty(request.Developer) || string.IsNullOrWhiteSpace(request.Developer) || request.Developer.Length < 3)
        {
            return Results.BadRequest("Informe uma desenvolvedora válida.");
        }
        if (string.IsNullOrEmpty(request.Publisher) || string.IsNullOrWhiteSpace(request.Publisher) || request.Publisher.Length < 3)
        {
            return Results.BadRequest("Informe uma editora válida.");
        }

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

        await context.Games.AddAsync(game);
        await context.SaveChangesAsync();

        return Results.Created($"/games/{game.Id}", game.Id);
    }    
}
