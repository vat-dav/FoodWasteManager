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
     
        
        public enum ApplicationStatus
        {
           Approved,Declined
        }

        [Required]
        public ApplicationStatus AStatus { get; set; }
        public enum OrderStatus
        {
            Approved, Declined
        }

        [Required]
        public OrderStatus OStatus { get; set; }



        
       
    }
}
