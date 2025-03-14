using FoodWasteManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Models;

namespace FoodWasteManager.Data;

public class FoodWasteManagerContext : IdentityDbContext<FoodWasteManagerUser>
{
    public FoodWasteManagerContext(DbContextOptions<FoodWasteManagerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
 
    }

public DbSet<FoodWasteManager.Models.Application> Application { get; set; } = default!;

public DbSet<FoodWasteManager.Models.Charity> Charity { get; set; } = default!;

public DbSet<FoodWasteManager.Models.FoodPost> FoodPost { get; set; } = default!;

public DbSet<FoodWasteManager.Models.Restaurant> Restaurant { get; set; } = default!;

public DbSet<FoodWasteManager.Models.RestaurantHour> RestaurantHour { get; set; } = default!;
}
