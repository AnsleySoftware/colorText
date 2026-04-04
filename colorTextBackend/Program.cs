var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
var app = builder.Build();


app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
