using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodWasteManager.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FoodWasteManagerUser class
public class FoodWasteManagerUser : IdentityUser
{
    public string Location { get; set; }
}

