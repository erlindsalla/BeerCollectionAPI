using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerCollectionAPI.Models;

namespace BeerCollectionAPI.Data
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> GetBeerByIdAsync(Guid id);
        Task<IEnumerable<Beer>> SearchBeersByNameAsync(string searchTerm);
        Task<Beer> AddBeerAsync(Beer beer);
        Task<Beer> UpdateBeerRatingAsync(Guid id, int rating);
    }
}