using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private readonly AuctionDbContext _context;

        private readonly IMapper _mapper;

        public AuctionsController(AuctionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
        {
            var Auctions = await _context.Auctions.
                                Include(x => x.Item)
                               .OrderBy(x => x.Item.Id)
                               .ToListAsync();
            return _mapper.Map<List<AuctionDto>>(Auctions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id) 
        {
            var Auction = await _context.Auctions.
                                Include(x => x.Item)
                                .FirstOrDefaultAsync(x =>x.Id ==id);
            if (Auction == null) return NotFound();
            return _mapper.Map<AuctionDto>(Auction);
        }
        [HttpPost]
        public async Task<ActionResult<CreateAuctionDto>> CreateAuction(CreateAuctionDto auctionDto)
        {
            var Auction = _mapper.Map<Auction>(auctionDto);

            _context.Auctions.Add(Auction);
            var Result =await _context.SaveChangesAsync() > 0;
            if (!Result) return BadRequest("could not save changes to db");

            return CreatedAtAction(nameof(GetAuctionById)
                ,new { Auction.Id}, _mapper.Map<AuctionDto>(Auction));
        }
    }
}