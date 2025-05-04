using System.ComponentModel.DataAnnotations;

namespace BeerCollectionAPI.Models
{
    public class UpdateRatingDto
    {
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}