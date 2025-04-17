using FoodWasteManager.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodPost
    {
        [Key]
        public int FoodPostId { get; set; } // PK for table

        [Display(Name = "Image")]
        public string FoodImage { get; set; } // Image file name or path (string stored in DB)

        [NotMapped]
        public IFormFile ImageFile { get; set; } // Not mapped, used to upload image via form

        [Required, MaxLength(25), Display(Name = "Name")]
        public string FoodName { get; set; } // Required food name with max length 25, display name is Name

        [Required, Display(Name = "Quantity")]
        public int FoodQuantity { get; set; } // Required quantity field, display name is Quantity

        [Required, Display(Name = "Price"), Range(0, 50, ErrorMessage = "Please enter a price between $0-50")]
        public int FoodPrice { get; set; } // Required price field (0–50), display name is Price

        [Required, DataType(DataType.Date), Display(Name = "Best Before")]
        public DateOnly FoodBestBefore { get; set; } // Required date field, display name is Best Before

        [Required, Display(Name = "Posted On")]
        public DateTime DatePosted { get; set; } // Required date field for when the post was made, display name is Posted On

        [Required]
        public string UserId { get; set; } // FK to FoodWasteManagerUser table

        [ForeignKey("UserId")]
        public FoodWasteManagerUser Users { get; set; } // Navigation property to FoodWasteManagerUser

        public ICollection<Application> Applications { get; set; } // One-to-many relationship with Application table

        [ForeignKey("FoodType"), Display(Name = "Category")]
        public int FoodTypeId { get; set; } // FK to FoodType table, display name is Category

        public FoodType FoodTypes { get; set; } // Navigation property to FoodType
    }
}
