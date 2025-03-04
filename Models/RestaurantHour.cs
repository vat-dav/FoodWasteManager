using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class RestaurantHour
    {
        public enum RestaurantDay
        {
            Monday, Tuesday, Wednesday, Thursday, Friday
        }

        [Key]
        public int RestaurantHourId { get; set; }
       
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public RestaurantDay Day { get; set; }
        [Required]
        public TimeOnly OpeningHours { get; set; }
        [Required]
        public TimeOnly ClosingHours { get; set; }

    }
}
