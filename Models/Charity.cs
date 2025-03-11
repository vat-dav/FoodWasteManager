using System.ComponentModel.DataAnnotations;

namespace FoodWasteManager.Models
{
    public class Charity
    {
        [Key]
        public int CharityId { get; set; }
       
       [Required,MaxLength(50)]
        public string CharityName { get; set; } // name of charity in string value limited to 50 characters
        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
        public string CharityPhone { get; set; } // phone number of charity with RegEx for validation
        [Required, EmailAddress]
        public string CharityEmail { get; set; } //string value with email address data annotation validation
        [Required, MaxLength(150)]
        public string CharityAddress { get; set; } // address of charity in string value limited to 50 characters
        public ICollection<Application> Applications { get; set; } //relationship with Applications table

    }
}
