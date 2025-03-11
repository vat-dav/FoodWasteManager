using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        [Required]
        public int FoodPostId { get; set; }
        [Required]
        public int CharityId { get; set; }
     
        
        public enum ApplicationStatus //enum allows for better structure of data
        {
           Approved,Declined
        }

        [Required]
        public ApplicationStatus AStatus { get; set; } // whether application is approved or declined
        public enum OrderStatus
        {
            ReadyForPickup, Processing
        }

        [Required]
        public OrderStatus? OStatus { get; set; } //whether order is ready or still in processing

     


        
       
    }
}
