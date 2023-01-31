namespace PAM.Endpoints.Managers;

public class ManagerGetAll
{
    public static string Template => "/managers";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "ManagerPolicy")]
    public static async Task<IResult> Action(UserManager<IdentityUser> users)
    {
        var search = users.Users.ToList();

        var managers = new List<ManagerResponse>();

        foreach (var item in search)
        {
            var claim = users.GetClaimsAsync(item).Result;
            var claimName = claim.FirstOrDefault(c => c.Type == "Name");
            var claimCode = claim.FirstOrDefault(c => c.Type == "ManagerCode");

            var userName = claimName != null ? claimName.Value : string.Empty;
            var userCode = claimCode != null ? claimCode.Value : string.Empty;

            managers.Add(new ManagerResponse(userName, userCode, item.Email));
        }

        return Results.Ok(managers);
    }
}
