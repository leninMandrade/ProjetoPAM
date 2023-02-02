namespace PAM.Endpoints.Users;

public class UserPost
{
    public static string Template => "/users";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static async Task<IResult> Action(UserRequest request, UserManager<IdentityUser> manager)
    {
        if (request.Name == null || request.Email == null || request.Password == null || request.NickName == null)
        {
            return Results.BadRequest("Preencha os dados corretamente!");
        }

        var userIdentity = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email,
        };

        var identity = manager.CreateAsync(userIdentity, request.Password).Result;

        if (!identity.Succeeded)
        {
            Results.BadRequest(identity.Errors.ToList());
        }

        var userClaims = new List<Claim>
        {
            new Claim("NickName", request.NickName),
            new Claim("Name", request.Name)
        };

        var claims = manager.AddClaimsAsync(userIdentity, userClaims).Result;

        if (!claims.Succeeded)
        {
            return Results.BadRequest(claims.Errors.ToList());
        }

        return Results.Created($"/users/{userIdentity.Id}", userIdentity.Id);
    }
}
