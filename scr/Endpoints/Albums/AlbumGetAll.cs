using PAM.Infra.Data;

namespace PAM.Endpoints.Albums
{
    public class AlbumGetAll
    {
        public static string Template => "/albums";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var search = context.Albums.ToList();

            return Results.Ok(search);
        }
    }
}
