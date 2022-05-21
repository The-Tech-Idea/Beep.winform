var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddGraphQL();
app.MapGet("/", () => "Hello World!");

app.Run();
