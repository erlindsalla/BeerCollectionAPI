using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerCollectionAPI.Models
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<int> RawRatings { get; set; } = new List<int>();

        // Calculated property for average rating
        public double? AverageRating
        {
            get
            {
                if (RawRatings.Count == 0)
                    return null;

                return Math.Round(RawRatings.Average(), 2);
            }
        }
    }
}