using AuctionService.Data;
using AuctionService.Entities;
using Contracts;
using MassTransit;

namespace AuctionService.Counsumers
{
    public class AuctionFinishedconsumer : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _dbContext;

        public AuctionFinishedconsumer(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.Write("--> consuming Auction Finished");

            var Auction =await _dbContext.Auctions.FindAsync(context.Message.AuctionId);

            if (context.Message.ItemSold)
            {
                Auction.Winner = context.Message.Winner;
                Auction.SoldAmount = context.Message.Amount;
            }

            Auction.Status = Auction.SoldAmount > Auction.ReservePrice ?
                  Status.Finished : Status.ReserveNotMet;

            await _dbContext.SaveChangesAsync();
        }
    }
}
