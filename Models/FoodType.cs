using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodType
    {
        [Key]
        public int FoodTypeId { get; set; }
        [Required, MaxLength(50)]
        public string FoodTypeName { get; set; }

        public ICollection<FoodPost> FoodPosts { get; set; }
    }
}
