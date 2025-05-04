using System.ComponentModel.DataAnnotations;

namespace BeerCollectionAPI.Models
{
    public class CreateBeerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}