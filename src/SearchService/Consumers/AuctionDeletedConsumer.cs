using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Model;

namespace SearchService.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("---> consumeing Deleteing");

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (!result.IsAcknowledged) 
                throw new MessageException(typeof(AuctionDeleted),"problem Deleting Auction");
        }
    }
}
