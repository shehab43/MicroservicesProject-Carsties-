using Contracts;
using MassTransit;

namespace AuctionService.Counsumers
{
    public class AuctionCreatedFaultCounsumer : IConsumer<Fault<AuctionCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
        {
            Console.WriteLine("--> consuming faulty Creation");

            var exception = context.Message.Exceptions.First();

            if (exception.ExceptionType == "System.ArgumentException")
            {
                context.Message.Message.Model = "FooBar";
                await context.Publish(context.Message.Message);
                Console.WriteLine("--> sussfulyy publishing");

            }
            else
            {
                Console.WriteLine("--> No ArgumentException -- update error Dashbord ");

            }
        }
    }
}
