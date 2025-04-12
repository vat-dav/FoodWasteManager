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
        [Required, MaxLength(50)]
        public string UserFirstName { get; set; } // name of organisation in string value limited to 50 characters

    [Required, MaxLength(50)]
    public string UserLastName { get; set; } // name of organisation in string value limited to 50 characters

    [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$", ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'")]
        public string UserPhone { get; set; } // phone number of organisation with RegEx for validation

    [RegularExpression(@"^(0\d{8}|0\d-\d{3}-\d{4})$", ErrorMessage = "Please enter a valid landline number. Eg: '09-813-3900' or '098133900'")]

    public string? UserLandline { get; set; } // (nullable) landline number of organisation with RegEx for validation

        [Required, MaxLength(0)]
        public string UserAddress { get; set; } // address of organisation in string value limited to 50 characters



    public ICollection<FoodPost> FoodPosts { get; set; }
    public ICollection<Application> Applications { get; set; }





}

