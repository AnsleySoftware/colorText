var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
builder.WebHost.UseUrls("http://+:8080");
var app = builder.Build();


app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
