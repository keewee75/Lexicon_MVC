using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS default policy on all localhost ports
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//    policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//    });
//});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod());   
});

builder.Services.AddMvc();

//Add DbContext and specify what Db to connect to in DefaultConnection in file appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

//Add functionality for Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Add options for Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
});

//Add RazorPages for Identity
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();

// Enable CORS
app.UseCors();

//More functionality for Identity
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();


// app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "FeverCheck",
    pattern: "FeverCheck",
    defaults: new { controller = "Doctor", action = "Index" });

app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "GuessingGame",
    defaults: new { controller = "Home", action = "GuessingGame" });

app.Run();
