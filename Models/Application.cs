using FoodWasteManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWasteManager.Models
{
    public class Application

    {

            [Key]
            public int ApplicationId { get; set; }
            [Required, ForeignKey("FoodPost")]
            public int FoodPostId { get; set; }
            [Required]
            public DateTime EarliestPickup { get; set; }

            [Required]
            public DateTime LatestPickup { get; set; }
            public enum ApplicationStatus //enum allows for better structure of data
            {
                Approved, Declined
            }

            [Required]
            public ApplicationStatus AStatus { get; set; } // whether application is approved or declined

            public FoodWasteManagerUser User { get; set; }
            public FoodPost FoodPost { get; set; }



    }
    }


