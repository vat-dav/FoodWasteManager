using FoodWasteManager.Areas.Identity.Data;
using FoodWasteManager.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models

{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public int FoodPostId { get; set; }

        [ForeignKey("FoodPostId")]
        public FoodPost FoodPost { get; set; }

        [Required]
        public string UserId { get; set; } // FK to FoodWasteManagerUser

        [ForeignKey("UserId")]
        public FoodWasteManagerUser Users { get; set; }

        [Required]
        public int QuantityRequired { get; set; }

        [Required]
        public DateTime EarliestPickup { get; set; }

        [Required]
        public DateTime LatestPickup { get; set; }

        public enum ApplicationStatus
        {
            Approved, Declined, Processing
        }

        [Required]
        public ApplicationStatus AStatus { get; set; }
    }
}