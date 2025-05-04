using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerCollectionAPI.Models;
using BeerCollectionAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeersController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        // GET: api/beers
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Beer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await _beerService.GetAllBeersAsync();
            return Ok(beers);
        }

        // GET: api/beers/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Beer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBeerById(Guid id)
        {
            var beer = await _beerService.GetBeerByIdAsync(id);

            if (beer == null)
                return NotFound();

            return Ok(beer);
        }

        // GET: api/beers/search?term={searchTerm}
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<Beer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchBeers([FromQuery] string term)
        {
            var beers = await _beerService.SearchBeersByNameAsync(term);
            return Ok(beers);
        }

        // POST: api/beers
        [HttpPost]
        [ProducesResponseType(typeof(Beer), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBeer([FromBody] CreateBeerDto beerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var beer = await _beerService.CreateBeerAsync(beerDto);

            return CreatedAtAction(
                nameof(GetBeerById),
                new { id = beer.Id },
                beer);
        }

        // PUT: api/beers/{id}/rating
        [HttpPut("{id}/rating")]
        [ProducesResponseType(typeof(Beer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBeerRating(Guid id, [FromBody] UpdateRatingDto ratingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var beer = await _beerService.UpdateBeerRatingAsync(id, ratingDto);

            if (beer == null)
                return NotFound();

            return Ok(beer);
        }
    }
}