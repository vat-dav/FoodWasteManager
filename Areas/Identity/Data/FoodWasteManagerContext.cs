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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       
        modelBuilder.Entity<Application>()
            .HasOne(a => a.FoodPost)
            .WithMany(fp => fp.Applications)
            .HasForeignKey(a => a.FoodPostId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Application>()
       .HasOne(a => a.Users)
       .WithMany(u => u.Applications)
       .HasForeignKey(a => a.UserId)
       .OnDelete(DeleteBehavior.Restrict);

    }


    public DbSet<FoodPost> FoodPosts { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<FoodWasteManagerUser> Users {get; set; }




}