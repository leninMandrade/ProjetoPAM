namespace PAM.Endpoints.Employees;

public class EmployeePost
{
    public static string Template => "/employees";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(EmployeeRequest request, UserManager<IdentityUser> userManager)
    {
        if (request.Name == null || request.Email == null || request.Password == null)
        {
            return Results.BadRequest("Informe os dados corretamente");
        }

        var employee = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var user = userManager.CreateAsync(employee, request.Password).Result;

        if (!user.Succeeded)
        {
            return Results.BadRequest(user.Errors.ToList());
        }      

        return Results.Created($"/employees/{employee.Id}", employee.Id);
    }
}
