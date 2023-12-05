using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtExtensions;

var builder = WebApplication.CreateBuilder(args);

var file=builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddJwtAuthentication();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");

app.Run();
