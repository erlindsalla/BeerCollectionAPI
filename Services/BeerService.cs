using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerCollectionAPI.Data;
using BeerCollectionAPI.Models;
using Microsoft.Extensions.Logging;

namespace BeerCollectionAPI.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;
        private readonly ILogger<BeerService> _logger;

        public BeerService(IBeerRepository beerRepository, ILogger<BeerService> logger)
        {
            _beerRepository = beerRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            _logger.LogInformation("Getting all beers");
            return await _beerRepository.GetAllBeersAsync();
        }

        public async Task<Beer> GetBeerByIdAsync(Guid id)
        {
            _logger.LogInformation($"Getting beer with ID: {id}");
            return await _beerRepository.GetBeerByIdAsync(id);
        }

        public async Task<IEnumerable<Beer>> SearchBeersByNameAsync(string searchTerm)
        {
            _logger.LogInformation($"Searching beers with term: {searchTerm}");
            return await _beerRepository.SearchBeersByNameAsync(searchTerm);
        }

        public async Task<Beer> CreateBeerAsync(CreateBeerDto beerDto)
        {
            _logger.LogInformation($"Creating new beer: {beerDto.Name}");

            var beer = new Beer
            {
                Name = beerDto.Name,
                Type = beerDto.Type
            };

            if (beerDto.Rating.HasValue)
            {
                beer.RawRatings.Add(beerDto.Rating.Value);
            }

            return await _beerRepository.AddBeerAsync(beer);
        }

        public async Task<Beer> UpdateBeerRatingAsync(Guid id, UpdateRatingDto ratingDto)
        {
            _logger.LogInformation($"Updating rating for beer ID: {id}");
            return await _beerRepository.UpdateBeerRatingAsync(id, ratingDto.Rating);
        }
    }
}