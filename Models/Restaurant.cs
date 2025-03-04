using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required, MaxLength(50)]
        public string RestaurantName { get; set; }

        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
  
        public string RestaurantPhone { get; set; }
        [Required]

        public string RestaurantEmail { get; set; }

        [Required, MaxLength(150)]
        public string RestaurauntAddress { get; set; }

        public ICollection<RestaurantHour> RestaurantHours { get; set; }
        public ICollection<FoodPost> FoodPosts { get; set; }
    }
}
