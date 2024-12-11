using MassTransit;
using MongoDB.Driver;
using MongoDB.Entities;
using Polly;
using Polly.Extensions.Http;
using SearchService.Data;
using SearchService.Model;
using SearchService.Service;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient<AuctionSvcHttpClien>().AddPolicyHandler(GetPolicy());
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((Context, cfg) =>
    {
        cfg.ConfigureEndpoints(Context);
    });
});
var app = builder.Build();


app.UseAuthorization();

app.MapControllers();
app.Lifetime.ApplicationStarted.Register(async ()=>
{
    try
    {
        await DbInitializer.InitDb(app);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
});
app.Run();

static IAsyncPolicy<HttpResponseMessage> GetPolicy()
    => HttpPolicyExtensions
       .HandleTransientHttpError()
       .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
       .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));
