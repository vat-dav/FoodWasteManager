using FoodWasteManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWasteManager.Models
{
    public class FoodPost
    {
        [Key]
        public int FoodPostId { get; set; } // unique identifier for each foodpost
        public string FoodImage { get; set; } // image of food available stored as a string value in wwroot folder
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required, MaxLength(25)]
        public string FoodName { get; set; } // food name in string value limited to 50 characters
        [Required]

        public int FoodQuantity { get; set; } // food int in food quantity limited to 50 characters
        [Required, Range(0, 500, ErrorMessage="Please enter a price between $0-$500")]

        public int FoodPrice { get; set; } // food int in food quantity limited to 50 characters

        [Required, DataType(DataType.Date)] // add front end validation
        public DateOnly FoodBestBefore { get; set; } // I will be adding front end validation for these field
        [Required] // add front end validation
        public DateTime DatePosted { get; set; }
        [ForeignKey("User")]
        public string Id { get; set; }
        public FoodWasteManagerUser User { get; set; }
        public ICollection<Application> Applications { get; set; } // relation with applications table


    }
}
