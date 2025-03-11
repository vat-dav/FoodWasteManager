using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodPost
    {
        [Key]
        public int FoodPostId { get; set; } // unique identifier for each foodpost
        [Required]
        public int RestauarantId { get; set; } // unique identifier for each restaurant
        [Required,MaxLength(50)]
        public string FoodName { get; set; } // food name in string value limited to 50 characters
        [Required]
        public string FoodImage { get; set; } // image of food available stored as a string value in wwroot folder

        [Required] // add front end validation
        public DateOnly FoodBestBefore { get; set; } // I will be adding front end validation for these field
        [Required] // add front end validation
        public DateTime DatePosted { get; set; } //I will be adding front end validation for this field
        public ICollection<Application> Applications { get; set; } // relation with applications table


    }
}
