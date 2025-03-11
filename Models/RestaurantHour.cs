using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class RestaurantHour
    {
        public enum RestaurantDay
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        [Key]
        public int RestaurantHourId { get; set; } //unique identifier for RestaurantHourId
       
        [Required]
        public int RestaurantId { get; set; } //FK for each RestaurantId
        [Required]
        public RestaurantDay Day { get; set; }// enum of each day
        [Required]
        public TimeOnly OpeningHours { get; set; } // times that the restaurant is open 
        [Required]
        public TimeOnly ClosingHours { get; set; } // times the restaurant closes

    }
}
