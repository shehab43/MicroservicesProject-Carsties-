using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Data;
using SearchService.Model;
using SearchService.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient<AuctionSvcHttpClien>();
var app = builder.Build();

try
{
await	DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}
app.UseAuthorization();

app.MapControllers();

app.Run();
