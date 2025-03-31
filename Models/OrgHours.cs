using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class OrgHours: IdentityUser
    {
        public enum OrgDay
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        [Key]
        public int OrgHourId { get; set; } //unique identifier for RestaurantHourId

      
        [Required]
        public OrgDay Day { get; set; }// enum of each day
        [Required]
        public TimeOnly OpeningHours { get; set; } // times that the restaurant is open 
        [Required]
        public TimeOnly ClosingHours { get; set; } // times the restaurant closes
    }
}
