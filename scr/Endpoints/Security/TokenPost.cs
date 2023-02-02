namespace PAM.Endpoints.Security;

public class TokenPost
{
    public static string Template => "/tokens";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static async Task<IResult> Action(LoginRequest request, IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        var user = userManager.FindByEmailAsync(request.Email).Result;

        if (user == null)
        {
            return Results.BadRequest("Informe o Email");
        }
        if (!userManager.CheckPasswordAsync(user, request.Password).Result)
        {
            return Results.BadRequest("Senha Inválida!");
        }

        var claims = userManager.GetClaimsAsync(user).Result;

        var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });

        subject.AddClaims(claims);

        var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = configuration["JwtBearerTokenSettings:Audience"],
            Issuer = configuration["JwtBearerTokenSettings:Issuer"],
            Expires = DateTime.UtcNow.AddMinutes(20)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Results.Ok(new
        {
            token = tokenHandler.WriteToken(token),
        });
    }
}
