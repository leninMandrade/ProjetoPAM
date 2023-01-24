var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:PAMDb"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
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
app.MapMethods(AlbumDelete.Template, AlbumDelete.Methods, AlbumDelete.Handle);
app.MapMethods(AlbumGetAll.Template, AlbumGetAll.Methods, AlbumGetAll.Handle);
app.MapMethods(AlbumGetAllResumed.Template, AlbumGetAllResumed.Methods, AlbumGetAllResumed.Handle);
app.MapMethods(AlbumGetByIdDetailed.Template, AlbumGetByIdDetailed.Methods, AlbumGetByIdDetailed.Handle);
app.MapMethods(AlbumGetByIdResumed.Template, AlbumGetByIdResumed.Methods, AlbumGetByIdResumed.Handle);

app.MapMethods(BookPost.Template, BookPost.Methods, BookPost.Handle);
app.MapMethods(BookGetAll.Template, BookGetAll.Methods, BookGetAll.Handle);
app.MapMethods(BookGetAllResumed.Template, BookGetAllResumed.Methods, BookGetAllResumed.Handle);
app.MapMethods(BookGetByIdDetailed.Template, BookGetByIdDetailed.Methods, BookGetByIdDetailed.Handle);
app.MapMethods(BookGetByIdResumed.Template, BookGetByIdResumed.Methods, BookGetByIdResumed.Handle);
app.MapMethods(BookPut.Template, BookPut.Methods, BookPut.Handle);
app.MapMethods(BookDelete.Template, BookDelete.Methods, BookDelete.Handle);

app.MapMethods(GamePost.Template, GamePost.Methods, GamePost.Handle);
app.MapMethods(GameGetAll.Template, GameGetAll.Methods, GameGetAll.Handle);
app.MapMethods(GameGetAllResumed.Template, GameGetAllResumed.Methods, GameGetAllResumed.Handle);
app.MapMethods(GameGetByIdDetailed.Template, GameGetByIdDetailed.Methods, GameGetByIdDetailed.Handle);
app.MapMethods(GameGetByIdResumed.Template, GameGetByIdResumed.Methods, GameGetByIdResumed.Handle);
app.MapMethods(GamePut.Template, GamePut.Methods, GamePut.Handle);
app.MapMethods(GameDelete.Template, GameDelete.Methods, GameDelete.Handle);

app.Run();