using AuctionService.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AuctionDbContext>(
    opt => { opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); }

);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((Context, cfg) =>
    {
        cfg.ConfigureEndpoints(Context);
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();




app.UseAuthorization();

app.MapControllers();
try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{

    Console.WriteLine(e);
}
app.Run();
