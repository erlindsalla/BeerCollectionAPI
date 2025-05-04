using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerCollectionAPI.Models;

namespace BeerCollectionAPI.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> GetBeerByIdAsync(Guid id);
        Task<IEnumerable<Beer>> SearchBeersByNameAsync(string searchTerm);
        Task<Beer> CreateBeerAsync(CreateBeerDto beerDto);
        Task<Beer> UpdateBeerRatingAsync(Guid id, UpdateRatingDto ratingDto);
    }
}