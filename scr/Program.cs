using PAM.Endpoints.Albums;
using PAM.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:PAMDb"]);
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(AlbumPost.Template, AlbumPost.Methods, AlbumPost.Handle);
app.MapMethods(AlbumPut.Template, AlbumPut.Methods, AlbumPut.Handle);
app.MapMethods(AlbumGetAll.Template, AlbumGetAll.Methods, AlbumGetAll.Handle);
app.MapMethods(AlbumGetAllResumed.Template, AlbumGetAllResumed.Methods, AlbumGetAllResumed.Handle);
app.MapMethods(AlbumGetByIdDetailed.Template, AlbumGetByIdDetailed.Methods, AlbumGetByIdDetailed.Handle);
app.MapMethods(AlbumGetByIdResumed.Template, AlbumGetByIdResumed.Methods, AlbumGetByIdResumed.Handle);
app.MapMethods(AlbumDelete.Template, AlbumDelete.Methods, AlbumDelete.Handle);

app.Run();