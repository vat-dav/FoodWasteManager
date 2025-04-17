using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Areas.Identity.Data;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("FoodWasteManagerContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodWasteManagerContextConnection' not found.");

        builder.Services.AddDbContext<FoodWasteManagerContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<FoodWasteManagerUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<FoodWasteManagerContext>(); //added Identity with role support.


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


        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Buyer", "Seller" }; //stores roles in an array

            foreach (var role in roles) // checks if each role is seeded in db, if not, it will insert into db
            {
                if (!await roleManager.RoleExistsAsync(role))
                     await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<FoodWasteManagerUser>>();



            string adminEmail = "admin@admin.co.nz"; //set admin email
            string adminPassword = "PassWord123!"; //set admin pass
            string adminPhone = "0221234567";
            string adminFirstName = "Alan";
            string adminLastName = "Mung";
            string adminAddress = "1293 Great North Road, Avondale, Auckland, 1026";


            if (await userManager.FindByEmailAsync(adminEmail) == null) //if the email is null, it adds db record
            {
                var user = new FoodWasteManagerUser();
                user.UserName = adminEmail;
                user.Email = adminEmail;
                user.UserPhone = adminPhone;
                user.UserLastName = adminLastName;
                user.UserFirstName = adminFirstName;
                user.UserAddress = adminAddress;
                user.AccessFailedCount = 0;
                
           
                   
                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, "Admin"); //adds the user to admin role
            }
        }

        app.Run();
    }

}