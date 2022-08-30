global using FastEndpoints;
using FastEndpoints.ClientGen;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(s =>
{
    s.DocumentName = "version 1"; // must match what's being passed in to the map methods below
});

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.MapCSharpClientEndpoint("/cs-client", "version 1", s =>
{
    s.ClassName                         = "ApiClient";
    s.CSharpGeneratorSettings.Namespace = "Namespace";
});

app.Run();