using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Model;

namespace SearchService.Service
{
    public class AuctionSvcHttpClien
    {
        private readonly IConfiguration _cofig;
        private readonly HttpClient _httpClient;

        public AuctionSvcHttpClien(IConfiguration cofig, HttpClient httpClient)
        {
            _cofig = cofig;
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetItemsForSearchDb()
        {
            var LAstUpdated = await DB.Find<Item, string>()
                .Sort(x =>x.Descending(a => a.UpdatedAt))
                .Project(x => x.UpdatedAt.ToString())
                .ExecuteFirstAsync();

            return await _httpClient.GetFromJsonAsync<List<Item>>(_cofig["AuctionServiceUrl"]+"/api/Auction?date=" +LAstUpdated);
        }
    }
}
