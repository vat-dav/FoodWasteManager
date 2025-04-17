using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodType
    {
        [Key]
        public int FoodTypeId { get; set; } // PK for table

        [Required, MaxLength(50), Display(Name = "Category")]
        public string FoodTypeName { get; set; } // Required field, max length 50, display name is Category

        public ICollection<FoodPost> FoodPosts { get; set; } // One-to-many relationship with FoodPost table
    }
}
