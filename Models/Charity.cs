using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWasteManager.Models
{
    public class Charity: IdentityUser
    {
        [Key]
        public int CharityId { get; set; }
        public ICollection<Application> Applications { get; set; } //relationship with Applications table

    }
}
