using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class FoodPost
    {
        [Key]
        public int FoodPostId { get; set; }
        [Required]
        public int RestauarantId { get; set; }
        [Required,MaxLength(50)]
        public string FoodName { get; set; }
        [Required]
        public string FoodImage { get; set; }
        [Required] // add front end validation
        public DateOnly FoodBestBefore { get; set; }
        [Required] // add front end validation
        public DateTime DatePosted { get; set; }
        public ICollection<Application> Applications { get; set; }


    }
}
