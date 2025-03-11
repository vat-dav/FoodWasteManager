using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; } //unique identifier for each restaurant

        [Required, MaxLength(50)]
        public string RestaurantName { get; set; } // name of restaurant stored as string value, required field with max length of 50 characters

        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
  
        public string RestaurantPhone { get; set; } // restaurant phone number, required field with RegEx
        [Required, EmailAddress]

        public string RestaurantEmail { get; set; }

        [Required, MaxLength(150)]
        public string RestaurauntAddress { get; set; } // restaurant address with string malue max limit of 150 characters

        public ICollection<RestaurantHour> RestaurantHours { get; set; } // relation with RestaurantHours table
        public ICollection<FoodPost> FoodPosts { get; set; } // relation with FoodPosts table
    }
}
