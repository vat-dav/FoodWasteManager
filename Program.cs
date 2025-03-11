using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FoodWasteManagerContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodWasteManagerContextConnection' not found.");

builder.Services.AddDbContext<FoodWasteManagerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FoodWasteManagerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FoodWasteManagerContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(); // added support for razor pages
            
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();  //added route to identity ui razor pages

app.Run();
