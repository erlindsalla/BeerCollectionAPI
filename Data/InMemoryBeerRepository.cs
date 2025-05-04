using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerCollectionAPI.Models;

namespace BeerCollectionAPI.Data
{
    public class InMemoryBeerRepository : IBeerRepository
    {
        private readonly List<Beer> _beers = new List<Beer>();

        public Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return Task.FromResult(_beers.AsEnumerable());
        }

        public Task<Beer> GetBeerByIdAsync(Guid id)
        {
            var beer = _beers.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(beer);
        }

        public Task<IEnumerable<Beer>> SearchBeersByNameAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Task.FromResult(_beers.AsEnumerable());

            var results = _beers
                .Where(b => b.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Task.FromResult(results.AsEnumerable());
        }

        public Task<Beer> AddBeerAsync(Beer beer)
        {
            beer.Id = Guid.NewGuid();
            _beers.Add(beer);
            return Task.FromResult(beer);
        }

        public async Task<Beer> UpdateBeerRatingAsync(Guid id, int rating)
        {
            var beer = await GetBeerByIdAsync(id);

            if (beer != null)
            {
                beer.RawRatings.Add(rating);
            }

            return beer;
        }
    }
}