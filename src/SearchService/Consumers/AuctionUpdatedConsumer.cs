﻿using AutoMapper;
using Contracts;
using MassTransit;
using SearchService.Model;
using MongoDB.Entities;
namespace SearchService.Consumers
{
    public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
    {
        private readonly IMapper _mapper;

        public AuctionUpdatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            Console.WriteLine("---> consumer auction Updated" + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            var result = await DB.Update<Item>()
                .Match(a =>a.ID == context.Message.Id)
                .ModifyOnly(x => new
                {
                    x.Color,
                    x.Make,
                    x.Model,
                    x.Year,
                    x.Mileage
                },item).ExecuteAsync();
            if (!result.IsAcknowledged) throw new MessageException(typeof(AuctionUpdated), "Problem updated mongoDb");

        }
    }
}
