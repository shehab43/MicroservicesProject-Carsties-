using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Model;
using SearchService.Service;
using System.Text.Json;

namespace SearchService.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app) 
        {
         await    DB.InitAsync("SearchDb",
                   MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

         await  DB.Index<Item>()
                .Key(x => x.Make, KeyType.Text)
                .Key(x => x.Model, KeyType.Text)
                .Key(x => x.Color, KeyType.Text)
                .CreateAsync();


            using var Scope = app.Services.CreateScope();

            var httpClient = Scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClien>();

            var items = await httpClient.GetItemsForSearchDb();

            Console.WriteLine(items.Count + "Returned from the auction service");

            if (items.Count > 0) await DB.SaveAsync(items);
            //var count = await DB.CountAsync<Item>();

            //if (count == 0)
            //{
            //    Console.WriteLine("Not Data -will attempt to seed");

            //    var itemData = await File.ReadAllTextAsync("Data/auctions.json");

            //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            //    var items =  JsonSerializer.Deserialize<List<Item>>(itemData, options);

            //  await  DB.SaveAsync(items);
            }

        }
    }
}
