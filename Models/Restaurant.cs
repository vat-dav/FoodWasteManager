using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Restaurant: IdentityUser
    {
        [Key]
        public int RestaurantId { get; set; } //unique identifier for each restaurant


        public ICollection<RestaurantHour> RestaurantHours { get; set; } // relation with RestaurantHours table
        public ICollection<FoodPost> FoodPosts { get; set; } // relation with FoodPosts table
    }
}
