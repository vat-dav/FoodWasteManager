
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodWasteManager.Data;
using FoodWasteManager.Areas.Identity.Data;
using System.Configuration;

/*

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FoodWasteManagerContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodWasteManagerContextConnection' not found.");



namespace FoodWasteManager







{
    public class Startup
    {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }
            builder.Services.AddDbContext<FoodWasteManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString(FoodWasteManagerContextConnection)))

    }
}
*/