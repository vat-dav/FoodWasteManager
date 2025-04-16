using FoodWasteManager.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodPost
    {
        [Key]
        public int FoodPostId { get; set; }

        public string FoodImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required, MaxLength(25)]
        public string FoodName { get; set; }

        [Required]
        public int FoodQuantity { get; set; }

        [Required, Range(0, 500, ErrorMessage = "Please enter a price between $0-$500")]
        public int FoodPrice { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly FoodBestBefore { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        public string UserId { get; set; } // FK to FoodWasteManagerUser

        [ForeignKey("UserId")]
        public FoodWasteManagerUser Users { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}