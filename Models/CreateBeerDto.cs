using System.ComponentModel.DataAnnotations;

namespace BeerCollectionAPI.Models
{
    public class CreateBeerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(BeerType), ErrorMessage = "Beer type must be one of: Pale, Ale, Heineken")]
        public BeerType Type { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}