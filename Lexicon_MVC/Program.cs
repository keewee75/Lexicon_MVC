var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();


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
