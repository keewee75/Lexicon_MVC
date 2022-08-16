var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "AboutMe",
    pattern: "AboutMe",
    defaults: new { controller = "Home", action = "AboutMe" });

app.MapControllerRoute(
    name: "Contact",
    pattern: "Contact",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "Projects",
    pattern: "Projects",
    defaults: new { controller = "Home", action = "Projects" });

app.MapControllerRoute(
    name: "test",
    pattern: "test",
    defaults: new { controller = "Home", action = "Test" });

app.Run();
