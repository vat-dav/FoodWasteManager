using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FoodWasteManager.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodWasteManager.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FoodWasteManagerUser class
    public class FoodWasteManagerUser : IdentityUser
    {
  
        public enum Role {Restaurant, Charity};


        [Required]
        public Role Roles { get; set; }


        [Required, MaxLength(50)]
        public string OrgName { get; set; } // name of organisation in string value limited to 50 characters

        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
        public string OrgPhone { get; set; } // phone number of organisation with RegEx for validation

        [RegularExpression(@"^09-\d{7}$", ErrorMessage = "Please enter a valid landline number, only numerics accepted. Eg.) '09-813-3900'")] // the regex is not working.
        public string? OrgLandline { get; set; } // (nullable) landline number of organisation with RegEx for validation

        [Required, MaxLength(150)]
        public string OrgAddress { get; set; } // address of organisation in string value limited to 50 characters

    [Required, MaxLength(200)]
    public string OrgDescription { get; set; } // address of organisation in string value limited to 50 characters

    public ICollection<FoodPost> FoodPosts { get; set; }
    public ICollection<OrgHour> OrgHours { get; set; }

   

    

}

