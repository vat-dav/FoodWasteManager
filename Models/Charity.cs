using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Charity
    {
        [Key]
        public int CharityId { get; set; }
       
       [Required,MaxLength(50)]
        public string CharityName { get; set; }
        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
        public string CharityPhone { get; set; }
        [Required]
        public string CharityEmail { get; set; }
        [Required, MaxLength(150)]
        public string CharityAddress { get; set; }
        public ICollection<Application> Applications { get; set; }

    }
}
