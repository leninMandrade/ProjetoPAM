using Microsoft.AspNetCore.Mvc;
using PAM.Domain.Albums;
using PAM.Infra.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace PAM.Endpoints.Albums;

public class AlbumPut
{
    public static string Template => "/albums/{Id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, AlbumRequest request, ApplicationDbContext context)
    {
        var search = context.Albums.Where(x => x.Id == Id).FirstOrDefault();

        search.Author = request.Artist;
        search.Name = request.AlbumName;
        search.Tracks = request.TracksNumbers;
        search.Lenght = request.Lenght;        
        search.Genre = request.Genre;
        search.Country = request.Country;

        context.SaveChanges();

        return Results.Accepted();
    }
}
