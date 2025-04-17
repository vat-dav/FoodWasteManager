using FoodWasteManager.Areas.Identity.Data;
using FoodWasteManager.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; } // PK for table

        [Required, Display(Name = "Food Item")]
        public int FoodPostId { get; set; } // FK to table (PK of FoodPosts table), is required and display name is Food Item

        [ForeignKey("FoodPostId")]
        public FoodPost FoodPost { get; set; } // Navigation property for relation with FoodPost table 

        [Required, Display(Name = "Applicant")]
        public string UserId { get; set; } // FK to table (PK of FoodWasteManagerUser table), display name is Applicant

        [ForeignKey("UserId")]
        public FoodWasteManagerUser Users { get; set; } // Navigation property for relation with FoodWasteManagerUser table

        [Required, Display(Name = "Quantity Requested")]
        public int QuantityRequired { get; set; } // Required field for quantity needed, display name is Quantity

        [Required, Display(Name = "Pickup From")]
        public DateTime EarliestPickup { get; set; } // Required field for earliest pickup time, display name is Pickup From

        [Required, Display(Name = "Pickup Until")]
        public DateTime LatestPickup { get; set; } // Required field for latest pickup time, display name is Pickup Until

        public enum ApplicationStatus
        {
            Approved, Declined, Processing // Enum for tracking application status
        }

        [Required, Display(Name = "Status")]
        public ApplicationStatus AStatus { get; set; } // Required field for application status, display name is Status
    }
}
