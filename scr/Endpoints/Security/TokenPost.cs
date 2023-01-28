namespace PAM.Endpoints.Security;

public class TokenPost
{
    public static string Template => "/tokens";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(LoginRequest request, IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        var userEmail = userManager.FindByEmailAsync(request.Email).Result;

        if (userEmail == null)
        {
            return Results.BadRequest("Informe o Email");
        }
        if (!userManager.CheckPasswordAsync(userEmail, request.Password).Result)
        {
            return Results.BadRequest("Senha Inválida!");
        }

        var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, request.Email)
            }),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            Audience = configuration["JwtBearerTokenSettings:Audience"],
            Issuer = configuration["JwtBearerTokenSettings:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Results.Ok(new
        {
            token = tokenHandler.WriteToken(token),
        });
    }
}
