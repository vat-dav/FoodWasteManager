using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodWasteManager.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodWasteManager.Areas.Identity.Data
{
    public class FoodWasteManagerUser : IdentityUser
    {
        [Required, MaxLength(50), Display(Name = "First Name")]
        public string UserFirstName { get; set; } // Required field, max length 50, display name is First Name

        [Required, MaxLength(50), Display(Name = "Last Name")]
        public string UserLastName { get; set; } // Required field, max length 50, display name is Last Name

        [Required, RegularExpression(@"^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$",
            ErrorMessage = "Please enter a valid phone number, only numerics accepted. Eg.) '0221234567'"), Display(Name = "Phone")]
        public string UserPhone { get; set; } // Required phone number field, display name is Phone

        [RegularExpression(@"^(0\d{8}|0\d-\d{3}-\d{4})$",
            ErrorMessage = "Please enter a valid landline number. Eg: '09-813-3900' or '098133900'"), Display(Name = "Landline")]
        public string? UserLandline { get; set; } // Optional landline field, display name is Landline

        [Required, MaxLength(250), Display(Name = "Address")]
        public string UserAddress { get; set; } // Required address field, max length 250, display name is Address

        public ICollection<FoodPost> FoodPosts { get; set; } // One-to-many relationship with FoodPost table

        public ICollection<Application> Applications { get; set; } // One-to-many relationship with Application table
    }
}
