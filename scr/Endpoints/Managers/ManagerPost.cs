using System.Security.Claims;

namespace PAM.Endpoints.Managers;

public class ManagerPost
{
    public static string Template => "/managers";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ManagerRequest request, UserManager<IdentityUser> userManager)
    {
        if (request.Name == null || request.Email == null || request.Password == null)
        {
            return Results.BadRequest("Informe os dados corretamente");
        }

        var manager = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var user = userManager.CreateAsync(manager, request.Password).Result;
        if (!user.Succeeded)
        {
            return Results.BadRequest(user.Errors.ToList());
        }

        var managerClaims = new List<Claim>
        {
            new Claim("ManagerCode", request.ManagerCode),
            new Claim("Name", request.Name)
        };

        var claims = userManager.AddClaimsAsync(manager, managerClaims).Result;

        if (claims == null)
        {
            return Results.BadRequest(claims.Errors.ToList());
        }

        return Results.Created($"/managers/{manager.Id}", manager.Id);
    }
}
